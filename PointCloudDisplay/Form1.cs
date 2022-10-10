using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;
using laszip.net;

namespace PointCloudDisplay
{
    public struct MyPoint
    {
        public Vector3d point;
        public Vector3d color;
    }
    public struct Point3DExt
    {
        public Vector3d point;
        public Vector3d color;
        public float flag;
    }

    public partial class Form1 : Form
    {
        private int graphDraw = 0;//基本图形绘制选择
        private int projection = 0;//投影方式选择

        public Form1()
        {
            InitializeComponent();
        }
        private void InitialGL()
        {
            GL.ShadeModel(ShadingModel.Smooth); // 启用平滑渲染。默认
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f); // 黑色背景。默认
            GL.ClearDepth(1f); // 设置深度缓存。默认1
            GL.Enable(EnableCap.DepthTest); // 启用深度测试。默认关闭
            SetupViewport();
        }

        double ViewAngle = 90;
        private void SetupViewport()
        {
            int w = glControl1.ClientSize.Width;
            int h = glControl1.ClientSize.Height;
            GL.MatrixMode(MatrixMode.Projection); // 后面将对投影做操作
            GL.LoadIdentity();
            double aspect;
            if (projection == 1)
            {
                aspect = (w >= h) ? (1.0 * w / h) : (1.0 * h / w);
                if (w <= h)
                    GL.Ortho(-1, 1, -aspect, aspect, -1, 1); //宽小于高，扩大Y
                else
                    GL.Ortho(-aspect, aspect, -1, 1, -1, 1); //宽大于高，扩大X 
            }
            if (projection == 0)
            {
                aspect = w / (double)h;
                like_gluPerspective(ViewAngle, aspect, 0.001, 10);
            }
            GL.Viewport(0, 0, w, h); //像素单位，指定OpenGL视口在窗口中的大小

        }
        public void like_gluPerspective(double fovy, double aspect, double near, double far)
        {
            const double DEG2RAD = 3.14159265 / 180.0;
            double tangent = Math.Tan(fovy / 2 * DEG2RAD);
            double height = near * tangent;
            double width = height * aspect;
            GL.Frustum(-width, width, -height, height, near, far);
        }

        double[,] mFrustum = new double[6, 4];
        public void CalculateFrustum()
        {
            Matrix4 projectionMatrix = new Matrix4();
            GL.GetFloat(GetPName.ProjectionMatrix, out projectionMatrix);
            Matrix4 modelViewMatrix = new Matrix4();
            GL.GetFloat(GetPName.ModelviewMatrix, out modelViewMatrix);
            float[] _clipMatrix = new float[16];
            const int RIGHT = 0, LEFT = 1, BOTTOM = 2, TOP = 3, BACK = 4, FRONT = 5;
            _clipMatrix[0] = (modelViewMatrix.M11 * projectionMatrix.M11) +
           (modelViewMatrix.M12 * projectionMatrix.M21) + (modelViewMatrix.M13 *
           projectionMatrix.M31) + (modelViewMatrix.M14 * projectionMatrix.M41);
            _clipMatrix[1] = (modelViewMatrix.M11 * projectionMatrix.M12) +
           (modelViewMatrix.M12 * projectionMatrix.M22) + (modelViewMatrix.M13 *
           projectionMatrix.M32) + (modelViewMatrix.M14 * projectionMatrix.M42);
            _clipMatrix[2] = (modelViewMatrix.M11 * projectionMatrix.M13) +
           (modelViewMatrix.M12 * projectionMatrix.M23) + (modelViewMatrix.M13 *
           projectionMatrix.M33) + (modelViewMatrix.M14 * projectionMatrix.M43);
            _clipMatrix[3] = (modelViewMatrix.M11 * projectionMatrix.M14) +
           (modelViewMatrix.M12 * projectionMatrix.M24) + (modelViewMatrix.M13 *
           projectionMatrix.M34) + (modelViewMatrix.M14 * projectionMatrix.M44);
            _clipMatrix[4] = (modelViewMatrix.M21 * projectionMatrix.M11) +
           (modelViewMatrix.M22 * projectionMatrix.M21) + (modelViewMatrix.M23 *
           projectionMatrix.M31) + (modelViewMatrix.M24 * projectionMatrix.M41);
            _clipMatrix[5] = (modelViewMatrix.M21 * projectionMatrix.M12) +
           (modelViewMatrix.M22 * projectionMatrix.M22) + (modelViewMatrix.M23 *
           projectionMatrix.M32) + (modelViewMatrix.M24 * projectionMatrix.M42);
            _clipMatrix[6] = (modelViewMatrix.M21 * projectionMatrix.M13) +
           (modelViewMatrix.M22 * projectionMatrix.M23) + (modelViewMatrix.M23 *
           projectionMatrix.M33) + (modelViewMatrix.M24 * projectionMatrix.M43);
            _clipMatrix[7] = (modelViewMatrix.M21 * projectionMatrix.M14) +
           (modelViewMatrix.M22 * projectionMatrix.M24) + (modelViewMatrix.M23 *
           projectionMatrix.M34) + (modelViewMatrix.M24 * projectionMatrix.M44);
            _clipMatrix[8] = (modelViewMatrix.M31 * projectionMatrix.M11) +
           (modelViewMatrix.M32 * projectionMatrix.M21) + (modelViewMatrix.M33 *
           projectionMatrix.M31) + (modelViewMatrix.M34 * projectionMatrix.M41);
            _clipMatrix[9] = (modelViewMatrix.M31 * projectionMatrix.M12) +
           (modelViewMatrix.M32 * projectionMatrix.M22) + (modelViewMatrix.M33 *
           projectionMatrix.M32) + (modelViewMatrix.M34 * projectionMatrix.M42);
            _clipMatrix[10] = (modelViewMatrix.M31 * projectionMatrix.M13) +
           (modelViewMatrix.M32 * projectionMatrix.M23) + (modelViewMatrix.M33 *
           projectionMatrix.M33) + (modelViewMatrix.M34 * projectionMatrix.M43);
            _clipMatrix[11] = (modelViewMatrix.M31 * projectionMatrix.M14) +
           (modelViewMatrix.M32 * projectionMatrix.M24) + (modelViewMatrix.M33 *
           projectionMatrix.M34) + (modelViewMatrix.M34 * projectionMatrix.M44);
            _clipMatrix[12] = (modelViewMatrix.M41 * projectionMatrix.M11) +
           (modelViewMatrix.M42 * projectionMatrix.M21) + (modelViewMatrix.M43 *
           projectionMatrix.M31) + (modelViewMatrix.M44 * projectionMatrix.M41);
            _clipMatrix[13] = (modelViewMatrix.M41 * projectionMatrix.M12) +
           (modelViewMatrix.M42 * projectionMatrix.M22) + (modelViewMatrix.M43 *
           projectionMatrix.M32) + (modelViewMatrix.M44 * projectionMatrix.M42);
            _clipMatrix[14] = (modelViewMatrix.M41 * projectionMatrix.M13) +
           (modelViewMatrix.M42 * projectionMatrix.M23) + (modelViewMatrix.M43 *
           projectionMatrix.M33) + (modelViewMatrix.M44 * projectionMatrix.M43);
            _clipMatrix[15] = (modelViewMatrix.M41 * projectionMatrix.M14) +
           (modelViewMatrix.M42 * projectionMatrix.M24) + (modelViewMatrix.M43 *
           projectionMatrix.M34) + (modelViewMatrix.M44 * projectionMatrix.M44);
            mFrustum[RIGHT, 0] = _clipMatrix[3] - _clipMatrix[0];
            mFrustum[RIGHT, 1] = _clipMatrix[7] - _clipMatrix[4];
            mFrustum[RIGHT, 2] = _clipMatrix[11] - _clipMatrix[8];
            mFrustum[RIGHT, 3] = _clipMatrix[15] - _clipMatrix[12];
            NormalizePlane(mFrustum, RIGHT);
            mFrustum[LEFT, 0] = _clipMatrix[3] + _clipMatrix[0];
            mFrustum[LEFT, 1] = _clipMatrix[7] + _clipMatrix[4];
            mFrustum[LEFT, 2] = _clipMatrix[11] + _clipMatrix[8];
            mFrustum[LEFT, 3] = _clipMatrix[15] + _clipMatrix[12];
            NormalizePlane(mFrustum, LEFT);
            mFrustum[BOTTOM, 0] = _clipMatrix[3] + _clipMatrix[1];
            mFrustum[BOTTOM, 1] = _clipMatrix[7] + _clipMatrix[5];
            mFrustum[BOTTOM, 2] = _clipMatrix[11] + _clipMatrix[9];
            mFrustum[BOTTOM, 3] = _clipMatrix[15] + _clipMatrix[13];
            NormalizePlane(mFrustum, BOTTOM);
            mFrustum[TOP, 0] = _clipMatrix[3] - _clipMatrix[1];
            mFrustum[TOP, 1] = _clipMatrix[7] - _clipMatrix[5];
            mFrustum[TOP, 2] = _clipMatrix[11] - _clipMatrix[9];
            mFrustum[TOP, 3] = _clipMatrix[15] - _clipMatrix[13];
            NormalizePlane(mFrustum, TOP);
            mFrustum[BACK, 0] = _clipMatrix[3] - _clipMatrix[2];
            mFrustum[BACK, 1] = _clipMatrix[7] - _clipMatrix[6];
            mFrustum[BACK, 2] = _clipMatrix[11] - _clipMatrix[10];
            mFrustum[BACK, 3] = _clipMatrix[15] - _clipMatrix[14];
            NormalizePlane(mFrustum, BACK);
            mFrustum[FRONT, 0] = _clipMatrix[3] + _clipMatrix[2];
            mFrustum[FRONT, 1] = _clipMatrix[7] + _clipMatrix[6];
            mFrustum[FRONT, 2] = _clipMatrix[11] + _clipMatrix[10];
            mFrustum[FRONT, 3] = _clipMatrix[15] + _clipMatrix[14];
            NormalizePlane(mFrustum, FRONT);
        }
        private void NormalizePlane(double[,] frustum, int side)
        {
            double magnitude = Math.Sqrt((frustum[side, 0] * frustum[side, 0]) +
           (frustum[side, 1] * frustum[side, 1]) + (frustum[side, 2] * frustum[side, 2]));
            frustum[side, 0] /= magnitude;
            frustum[side, 1] /= magnitude;
            frustum[side, 2] /= magnitude;
            frustum[side, 3] /= magnitude;
        }
        private void Render()
        {
            glControl1.MakeCurrent(); //后续OpenGL显示操作在当前控件窗口内进行
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //清除当前帧已有内容，清除深度测试缓冲区

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();//清除之前的操作
            GL.Translate(0, 0, -1);
            GL.Rotate(-angleX, 1, 0, 0);
            GL.Rotate(-angleZ, 0, 1, 0);//GL中后面操作先进行
            if (graphDraw == 1)
            {
                DrawSphere();
                tree = null;
            }
                
            if (graphDraw == 2)
            {
                DrawTriangle();
                tree = null;
            }
                
            else if (tree != null)
            {
                CalculateFrustum();
                tree.Render(mFrustum, ptClosest);
            }

            glControl1.SwapBuffers();
        }
        private void DrawTriangle()
        {
            GL.Begin(PrimitiveType.LineLoop); 
            GL.Color4(Color4.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Color4(Color4.Red);
            GL.Vertex3(1, 0, 0);
            GL.Color4(Color4.Green);
            GL.Vertex3(1, 1, 0);
            GL.End();
        }
        private void DrawSphere()
        {
            const double radius = 0.5;
            const int step = 5;
            int xWidth = 360 / step + 1;
            int zHeight = 180 / step + 1;
            int halfZHeight = (zHeight - 1) / 2;
            double xx, yy, zz;
            GL.Begin(PrimitiveType.Points);
            GL.Color4(color);
            for (int z = -halfZHeight; z <= halfZHeight; z++)
            {
                for (int x = 0; x < xWidth; x++)
                {
                    xx = radius * Math.Cos(x * step * Math.PI / 180)
                   * Math.Cos(z * step * Math.PI / 180.0);
                    zz = radius * Math.Sin(x * step * Math.PI / 180)
                   * Math.Cos(z * step * Math.PI / 180.0);
                    yy = radius * Math.Sin(z * step * Math.PI / 180);
                    GL.Vertex3(xx, yy, zz);
                }
            }
            GL.End();
        }

        //鼠标控制模型变换
        Point oldLeftMousePos;
        Point oldRightMousePos;
        bool bLeftPushed = false;
        bool bRightPushed = false;

        float angleX = 0.0f;
        float angleZ = 0.0f;

        private void glControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                oldLeftMousePos = e.Location;
                bLeftPushed = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                oldRightMousePos = e.Location;
                bRightPushed = true;
            }
        }

        private void glControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (bLeftPushed)
            {
                angleZ += (e.Location.X - oldLeftMousePos.X) / 3.0f;
                angleX += (e.Location.Y - oldLeftMousePos.Y) / 3.0f;
                oldLeftMousePos = e.Location;
                
                this.Invalidate();//使当前窗口无效并调用窗口的paint函数
            }
            if (bRightPushed)
            {
                ViewAngle -= (e.Location.Y - oldRightMousePos.Y) / 3.0f;
                oldRightMousePos = e.Location;
                SetupViewport();
                
                this.Invalidate();
            }
        }

        private void glControl1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bLeftPushed = false;
            bRightPushed = false;
        }

        private string fName = null;
        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "LAS文件|*.las|所有文件|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fName = openFileDialog.FileName;
                //MessageBox.Show(fName);
                ReadPointFromFile(fName);
            }
            Invalidate();
        }

        octree tree;
        private void ReadPointFromFile(string fName)
        {
            var lazReader = new laszip_dll();
            var compressed = true;
            lazReader.laszip_open_reader(fName, ref compressed); //FileName要给定
            var numberOfPoints = lazReader.header.number_of_point_records;
            //las文件中三维点的范围
            double minx = lazReader.header.min_x;
            double miny = lazReader.header.min_y;
            double minz = lazReader.header.min_z;
            double maxx = lazReader.header.max_x;
            double maxy = lazReader.header.max_y;
            double maxz = lazReader.header.max_z;
            double centx = (maxx - minx) / 2;
            double centy = (maxy - miny) / 2;
            double centz = (maxz - minz) / 2;
            double maxs = Math.Max(Math.Max(maxx - minx, maxy - miny), maxz - minz);
            int classification = 0;
            var coordArray = new double[3];
            MyPoint poin;
            List<MyPoint> points = new List<MyPoint>((int)numberOfPoints);
            Vector3d cr1 = new Vector3d(0.0f, 0.0f, 1.0f);
            Vector3d cr2 = new Vector3d(1.0f, 0.0f, 0.0f);

            //循环读取每个点
            for (int pointIndex = 0; pointIndex < numberOfPoints; pointIndex++)
            {
                // 读点
                lazReader.laszip_read_point();
                // 得到坐标值
                lazReader.laszip_get_coordinates(coordArray);
                poin.point.X = (coordArray[0] - centx) / maxs;   //3
                poin.point.Y = (coordArray[1] - centy) / maxs;
                poin.point.Z = (coordArray[2] - centz) / maxs;
                poin.color = (coordArray[2] - minz) / (maxz - minz) * (cr2 - cr1) + cr1;
                points.Add(poin);
                classification = lazReader.point.classification;
            }
            Vector3d sum = new Vector3d(0, 0, 0);
            for (int poinIndex = 0; poinIndex < points.Count; poinIndex++)
            {
                sum.X += points[poinIndex].point.X;
                sum.Y += points[poinIndex].point.Y;
                sum.Z += points[poinIndex].point.Z;
            }
            Vector3d gCenter;
            gCenter.X = sum.X / points.Count;
            gCenter.Y = sum.Y / points.Count;
            gCenter.Z = sum.Z / points.Count;

            //恢复默认视角
            graphDraw = 0;
            angleX = angleZ = 0;
            ViewAngle = 90;
            // 关闭
            lazReader.laszip_close_reader();

            //创建八叉树
            Vector3d minv, maxv, offset;
            minv.X = (minx - centx) / maxs;
            minv.Y = (miny - centy) / maxs;
            minv.Z = (minz - centz) / maxs;

            maxv.X = (maxx - centx) / maxs;
            maxv.Y = (maxy - centy) / maxs;
            maxv.Z = (maxz - centz) / maxs;

            offset.X = centx;
            offset.Y = centy;
            offset.Z = centz;

            tree = new octree(points, gCenter, minv, maxv, offset, maxs,level);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialGL();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            SetupViewport();
        }

        //投影方式
        private void 正交投影ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projection = 1;
            InitialGL();
            Invalidate();
        }

        private void 透视投影ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projection = 0;
            InitialGL();
            Render();
        }
        
        //基本图形
        private void RestoreDefault()
        {
            //切换图形时旋转恢复
            angleX = 0;
            angleZ = 0;
            //切换图形时恢复原始缩放
            ViewAngle = 90;
            SetupViewport();
        }

        private void 球体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphDraw = 1;
            RestoreDefault();
            Invalidate();
        }


        private void 三角形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphDraw = 2;
            RestoreDefault();
            Invalidate();
        }

        //点云着色
        private void 沿X轴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tree == null)
                return;
            tree.Colorize(0, color);
            Invalidate();
        }

        private void 沿Y轴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tree == null)
                return;
            tree.Colorize(1, color);
            Invalidate();
        }

        private void 沿Z轴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tree == null)
                return;
            tree.Colorize(2, color);
            Invalidate();
        }

        //颜色设定
        Color color = System.Drawing.Color.Yellow;
        private void button1_Click(object sender, EventArgs e)
        {
            // 打开颜色选择对话框 ,并分析是否选择了对话框中的确定按钮  
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
            }
            Invalidate();
            if (tree == null)
                return;

            //避免在渐变色时通过colordialog是点云变成纯色
            if (tree.mode != 3)
                return;
            tree.Colorize(3, color);
            Invalidate();
        }

        private void 纯色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tree == null)
                return;
            tree.Colorize(3, color);
            Invalidate();
        }

        //鼠标选点
        int UnProject(Vector3d win, ref Vector3d obj)
        {
            Matrix4d modelMatrix;
            GL.GetDouble(GetPName.ModelviewMatrix, out modelMatrix);
            Matrix4d projMatrix;
            GL.GetDouble(GetPName.ProjectionMatrix, out projMatrix);
            int[] viewport = new int[4];
            GL.GetInteger(GetPName.Viewport, viewport);
            return UnProject(win, modelMatrix, projMatrix, viewport, ref obj);
        }
        int UnProject(Vector3d win, Matrix4d modelMatrix,
        Matrix4d projMatrix, int[] viewport, ref Vector3d obj)
        {
            return like_gluUnProject(win.X, win.Y, win.Z, modelMatrix, projMatrix,
            viewport, ref obj.X, ref obj.Y, ref obj.Z);
        }
        int like_gluUnProject(double winx, double winy, double winz,
         Matrix4d modelMatrix, Matrix4d projMatrix, int[] viewport,
         ref double objx, ref double objy, ref double objz)
        {
            Matrix4d finalMatrix;
            Vector4d _in;
            Vector4d _out;
            finalMatrix = Matrix4d.Mult(modelMatrix, projMatrix);
            finalMatrix.Invert();
            _in.X = winx;
            _in.Y = viewport[3] - winy;
            _in.Z = winz;
            _in.W = 1.0f;
            // Map x and y from window coordinates
            _in.X = (_in.X - viewport[0]) / viewport[2];
            _in.Y = (_in.Y - viewport[1]) / viewport[3];
            // Map to range -1 to 1
            _in.X = _in.X * 2 - 1;
            _in.Y = _in.Y * 2 - 1;
            _in.Z = _in.Z * 2 - 1;
            //__gluMultMatrixVecd(finalMatrix, _in, _out);
            // check if this works:
            _out = Vector4d.Transform(_in, finalMatrix);
            if (_out.W == 0.0)
                return (0);
            _out.X /= _out.W;
            _out.Y /= _out.W;
            _out.Z /= _out.W;
            objx = _out.X;
            objy = _out.Y;
            objz = _out.Z;
            return (1);
        }

        Vector3d line;
        Point3DExt ptClosest;
        private void glControl1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Vector3d winxyz;
            winxyz.X = e.Location.X;
            winxyz.Y = e.Location.Y;
            winxyz.Z = 0.0f;

            Vector3d nearPoint = new Vector3d(0, 0, 0);
            UnProject(winxyz, ref nearPoint);

            winxyz.Z = 1.0f;
            Vector3d farPoint = new Vector3d(0, 0, 0);
            UnProject(winxyz, ref farPoint);

            line = farPoint - nearPoint;


            ptClosest.point = new Vector3d(0, 0, 0);
            ptClosest.color = new Vector3d(0, 0, 0);
            ptClosest.flag = float.MaxValue;
            if (tree != null)
                tree.FindClosestPoint(mFrustum, nearPoint, farPoint, line, ref ptClosest);
            Invalidate();
        }

        //取消显示鼠标选点
        private void button2_Click(object sender, EventArgs e)
        {
            ptClosest.flag = float.MaxValue;
            Invalidate();
        }

        //模型固定变换
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            angleZ += 30;
            Invalidate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            angleZ += 45;
            Invalidate();
        }

        private void 恢复为初始方向ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            angleZ = 0;
            Invalidate();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            angleZ += 90;
            Invalidate();
        }


        private void 恢复初始方向ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            angleX = 0;
            Invalidate();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            angleX += 30;
            Invalidate();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            angleX += 45;
            Invalidate();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            angleX += 90;
            Invalidate();
        }


        //分层显示
        int level = 1;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            level = 1;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            level = 4;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            level = 8;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            level = 32;
        }
    }
}
