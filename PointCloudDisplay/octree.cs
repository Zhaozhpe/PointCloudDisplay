using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace PointCloudDisplay
{
    class octNode
    {
        private static readonly int MAX_POINTS = 5000;
        private List<MyPoint> data; //点数据
        private octNode[] child; //8个子结点
        private Vector3d minc, maxc, gCenter;
        private int iShowList;
        

        
        public octNode()
        {
            data = null;
            child = null;
            iShowList = 0;
        }
        
        public octNode(List<MyPoint> d, Vector3d xyz,
        Vector3d minv, Vector3d maxv,int level) : this()
        {
            gCenter = xyz;
            minc = minv;
            maxc = maxv;
            if (d.Count <= MAX_POINTS) //把数据放入该结点的数组里
            {
                data = d;                                                   //1
                
                //创建显示列表
                iShowList = GL.GenLists(1);
                GL.NewList(iShowList, ListMode.Compile);
                GL.Begin(PrimitiveType.Points);
                for (int i = 0; i < data.Count; i+=level)
                {
                    GL.Color3(data[i].color.X, data[i].color.Y, data[i].color.Z);
                    GL.Vertex3(data[i].point.X, data[i].point.Y, data[i].point.Z);
                }
                GL.End();

                GL.EndList();
            }
            else //把数据放到子结点里
            {
                child = new octNode[8];
                List<MyPoint>[] listchild = new List<MyPoint>[8];           //2
                for (int i = 0; i < 8; i++)
                {
                    listchild[i] = new List<MyPoint>();
                }
                    
                Vector3d[] minva = new Vector3d[8];
                Vector3d[] maxva = new Vector3d[8];
                Vector3d[] gCentera = new Vector3d[8];
                

                foreach (MyPoint p in d)
                {
                    if (p.point.Z>gCenter.Z)
                    {
                        if(p.point.Y>gCenter.Y)
                        {
                            if(p.point.X>gCenter.X)
                            {
                                listchild[0].Add(p);
                                

                                gCentera[0].X += p.point.X;
                                gCentera[0].Y += p.point.Y;
                                gCentera[0].Z += p.point.Z;
                            }
                            else
                            {
                                listchild[1].Add(p);
                                
                                gCentera[1].X += p.point.X;
                                gCentera[1].Y += p.point.Y;
                                gCentera[1].Z += p.point.Z;
                            }
                        }
                        else
                        {
                            if (p.point.X > gCenter.X)
                            {
                                listchild[2].Add(p);
                                gCentera[2].X += p.point.X;
                                gCentera[2].Y += p.point.Y;
                                gCentera[2].Z += p.point.Z;
                            }
                            else
                            {
                                listchild[3].Add(p);
                                gCentera[3].X += p.point.X;
                                gCentera[3].Y += p.point.Y;
                                gCentera[3].Z += p.point.Z;
                            }
                        }
                    }
                    else
                    {
                        if (p.point.Y > gCenter.Y)
                        {
                            if (p.point.X > gCenter.X)
                            {
                                listchild[4].Add(p);
                                gCentera[4].X += p.point.X;
                                gCentera[4].Y += p.point.Y;
                                gCentera[4].Z += p.point.Z;
                            }
                            else
                            {
                                listchild[5].Add(p);
                                gCentera[5].X += p.point.X;
                                gCentera[5].Y += p.point.Y;
                                gCentera[5].Z += p.point.Z;
                            }
                        }
                        else
                        {
                            if (p.point.X > gCenter.X)
                            {
                                listchild[6].Add(p);
                                gCentera[6].X += p.point.X;
                                gCentera[6].Y += p.point.Y;
                                gCentera[6].Z += p.point.Z;
                            }
                            else
                            {
                                listchild[7].Add(p);
                                gCentera[7].X += p.point.X;
                                gCentera[7].Y += p.point.Y;
                                gCentera[7].Z += p.point.Z;
                            }
                        }
                    }
                }

                //求重心
                for (int i = 0; i < 8; i++)
                {
                    if (listchild[i].Count == 0)
                        continue;

                    gCentera[i].X /= listchild[i].Count;
                    gCentera[i].Y /= listchild[i].Count;
                    gCentera[i].Z /= listchild[i].Count;
                }

                //创建子节点
                for (int i = 0; i < 8; i++)
                {
                    if (listchild[i].Count == 0)
                        continue;

                    if (i == 0)
                    {
                        minva[i] = gCenter;
                        maxva[i] = maxv;
                    }
                    if (i == 1)
                    {
                        minva[i].X = minv.X;
                        minva[i].Y = gCenter.Y;
                        minva[i].Z = gCenter.Z;

                        maxva[i].X = gCenter.X;
                        maxva[i].Y = maxv.Y;
                        maxva[i].Z = maxv.Z;
                    }
                    if (i == 2)
                    {
                        minva[i].X = gCenter.X;
                        minva[i].Y = minv.Y;
                        minva[i].Z = gCenter.Z;

                        maxva[i].X = maxv.X;
                        maxva[i].Y = gCenter.Y;
                        maxva[i].Z = maxv.Z;
                    }
                    if (i == 3)
                    {
                        minva[i].X = minv.X;
                        minva[i].Y = minv.Y;
                        minva[i].Z = gCenter.Z;

                        maxva[i].X = gCenter.X;
                        maxva[i].Y = gCenter.Y;
                        maxva[i].Z = maxv.Z;
                    }
                    if (i == 4)
                    {
                        minva[i].X = gCenter.X;
                        minva[i].Y = gCenter.Y;
                        minva[i].Z = minv.Z;

                        maxva[i].X = maxv.X;
                        maxva[i].Y = maxv.Y;
                        maxva[i].Z = gCenter.Z;
                    }
                    if (i == 5)
                    {
                        minva[i].X = minv.X;
                        minva[i].Y = gCenter.Y;
                        minva[i].Z = minv.Z;

                        maxva[i].X = gCenter.X;
                        maxva[i].Y = maxv.Y;
                        maxva[i].Z = gCenter.Z;
                    }
                    if (i == 6)
                    {
                        minva[i].X = gCenter.X;
                        minva[i].Y = minv.Y;
                        minva[i].Z = minv.Z;

                        maxva[i].X = maxv.X;
                        maxva[i].Y = gCenter.Y;
                        maxva[i].Z = gCenter.Z;
                    }
                    if (i == 7)
                    {
                        minva[i] = minv;
                        maxva[i] = gCenter;
                    }
                    child[i] = new octNode(listchild[i], gCentera[i], minva[i], maxva[i],level);
                }
                }
                
            }
        public bool VoxelWithinFrustum(double[,] ftum, double minx, double miny, double minz,
        double maxx, double maxy, double maxz)
        {
            double x1 = minx, y1 = miny, z1 = minz;
            double x2 = maxx, y2 = maxy, z2 = maxz;
            for (int i = 0; i < 6; i++)
            {
                if ((ftum[i, 0] * x1 + ftum[i, 1] * y1 + ftum[i, 2] * z1 + ftum[i, 3] <= 0.0F) &&
                (ftum[i, 0] * x2 + ftum[i, 1] * y1 + ftum[i, 2] * z1 + ftum[i, 3] <= 0.0F) &&
                (ftum[i, 0] * x1 + ftum[i, 1] * y2 + ftum[i, 2] * z1 + ftum[i, 3] <= 0.0F) &&
                (ftum[i, 0] * x2 + ftum[i, 1] * y2 + ftum[i, 2] * z1 + ftum[i, 3] <= 0.0F) &&
                (ftum[i, 0] * x1 + ftum[i, 1] * y1 + ftum[i, 2] * z2 + ftum[i, 3] <= 0.0F) &&
                (ftum[i, 0] * x2 + ftum[i, 1] * y1 + ftum[i, 2] * z2 + ftum[i, 3] <= 0.0F) &&
                (ftum[i, 0] * x1 + ftum[i, 1] * y2 + ftum[i, 2] * z2 + ftum[i, 3] <= 0.0F) &&
                (ftum[i, 0] * x2 + ftum[i, 1] * y2 + ftum[i, 2] * z2 + ftum[i, 3] <= 0.0F))
                {
                    return false;
                }
            }
            return true;
        }
        public void Render(double[,] mFrustum, Point3DExt ptClosest)
        {
            if (!VoxelWithinFrustum(mFrustum, minc.X, minc.Y, minc.Z, maxc.X, maxc.Y, maxc.Z))
                return;
            if (data != null)
            {
                
                if (iShowList != 0)
                    GL.CallList(iShowList);
                for (int i = 0; i < data.Count; i++)    //鼠标选点显示
                {
                    if (data[i].point == ptClosest.point && ptClosest.flag!=float.MaxValue)
                    {
                        GL.Begin(PrimitiveType.LineLoop); 
                        GL.Color4(Color4.White);
                        GL.Vertex3(data[i].point.X, data[i].point.Y, data[i].point.Z);
                        GL.Color4(Color4.White);
                        GL.Vertex3(data[i].point.X + 0.1, data[i].point.Y + 0.1, data[i].point.Z);
                        GL.End();
                        GL.Begin(PrimitiveType.LineLoop);
                        GL.Color4(Color4.White);
                        GL.Vertex3(data[i].point.X , data[i].point.Y , data[i].point.Z);
                        GL.Color4(Color4.White);
                        GL.Vertex3(data[i].point.X + 0.1, data[i].point.Y - 0.1, data[i].point.Z);
                        GL.End();
                    }
                    else
                        continue;
                        
                }  
            }
            else
            {
                foreach (octNode n in child)
                {
                    if (n != null)
                        n.Render(mFrustum, ptClosest);
                }
            }
        }
        public void Colorize(int mode, Vector3d minv, Vector3d maxv, Color color)
        {
            if (data != null)
            {
                if (iShowList > 0)
                    GL.DeleteLists(iShowList, 1);

                //着色
                Vector3d cr1 = new Vector3d(0.0f, 0.0f, 1.0f);
                Vector3d cr2 = new Vector3d(1.0f, 0.0f, 0.0f);
                if (mode == 3)
                {
                    iShowList = GL.GenLists(1);
                    GL.NewList(iShowList, ListMode.Compile);
                    GL.Begin(PrimitiveType.Points);
                    for (int i = 0; i < data.Count; i++)
                    {
                        GL.Color4(color);
                        GL.Vertex3(data[i].point.X, data[i].point.Y, data[i].point.Z);
                    }
                    GL.End();

                    GL.EndList();
                }
                else
                {
                    if (mode == 0)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            MyPoint mp;
                            mp.color = (data[i].point.X - minv.X) / (maxv.X - minv.X) * (cr2 - cr1) + cr1;
                            mp.point = data[i].point;
                            data[i] = mp;
                        }
                    }
                    if (mode == 1)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            MyPoint mp;
                            mp.color = (data[i].point.Y - minv.Y) / (maxv.Y - minv.Y) * (cr2 - cr1) + cr1;
                            mp.point = data[i].point;
                            data[i] = mp;
                        }
                    }
                    if (mode == 2)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            MyPoint mp;
                            mp.color = (data[i].point.Z - minv.Z) / (maxv.Z - minv.Z) * (cr2 - cr1) + cr1;
                            mp.point = data[i].point;
                            data[i] = mp;
                        }
                    }
                    iShowList = GL.GenLists(1);
                    GL.NewList(iShowList, ListMode.Compile);
                    GL.Begin(PrimitiveType.Points);
                    for (int i = 0; i < data.Count; i++)
                    {
                        GL.Color3(data[i].color.X, data[i].color.Y, data[i].color.Z);
                        GL.Vertex3(data[i].point.X, data[i].point.Y, data[i].point.Z);
                    }
                    GL.End();

                    GL.EndList();
                }

            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (child[i] == null)
                        continue;
                    child[i].Colorize(mode, minv, maxv, color);
                }
            }

        }
        public void FindClosestPoint(double[,] mFrustum, Vector3d nearPoint, Vector3d farPoint, Vector3d line,
            ref Point3DExt ptClosest)
        {
            if (!VoxelWithinFrustum(mFrustum, minc.X, minc.Y, minc.Z, maxc.X, maxc.Y, maxc.Z))
                return;

            //本结点里找
            if (data != null)
            {
                Vector3d v, vcross;
                float dist;
                foreach (MyPoint p in data)
                {
                    v.X = p.point.X - farPoint.X;
                    v.Y = p.point.Y - farPoint.Y;
                    v.Z = p.point.Z - farPoint.Z;

                    vcross.X = line.Y * v.Z - line.Z * v.Y;
                    vcross.Y = line.Z * v.X - line.X * v.Z;
                    vcross.Z = line.X * v.Y - line.Y * v.X;
                    dist = (float)((vcross.Length) / line.Length);

                    if (ptClosest.flag > dist)
                    {
                        ptClosest.point = p.point;
                        ptClosest.flag = dist;
                    }
                }
            }
            else
            {
                if (child != null)
                    foreach (octNode on in child)
                        if (on != null)
                            on.FindClosestPoint(mFrustum, nearPoint, farPoint, line, ref ptClosest);
            }
        }

    }
    class octree
    {
        private octNode root;
        private Vector3d minv, maxv, gCenter;
        private Vector3d offset;
        private double scale;
        public int mode;
        public octree()
        {
            root = null;
        }
       
        public octree(List<MyPoint>d, Vector3d gCenter, Vector3d minv,Vector3d maxv,Vector3d offset,double scale,int level)
        {
            if(d.Count>0)
            {
                this.minv = minv;
                this.maxv = maxv;
                this.gCenter = gCenter;
                this.offset = offset;
                this.scale = scale;

                root = new octNode(d, gCenter, minv, maxv,level);
            }
        }
        public void Render(double[,] mFrustum, Point3DExt ptClosest)
        {
            if (root == null)
                return;
            root.Render(mFrustum,ptClosest);
        }
        public void Colorize(int mode, Color color)
        {
            if (root == null)
                return;
            this.mode = mode;//记录此时着色的状态 
            root.Colorize(mode, minv, maxv, color);
        }
        public void FindClosestPoint(double[,] mFrustum, Vector3d nearPoint, Vector3d farPoint, Vector3d line,
           ref Point3DExt ptClosest)
        {
            root.FindClosestPoint(mFrustum, nearPoint, farPoint, line, ref ptClosest);
        }
    }
}
