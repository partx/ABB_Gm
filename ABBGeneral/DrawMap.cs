//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNDDDDDDDDDDDDBBNNNNNNNNNNNNNNNNNNNNz<-'...'...'..'..<NNNN
//NNN<.            .'~zNNNNNNNNNNNNNNNs'                 .+NNN
//NNN.                 -zNNNNNNNNNNNN=.                   'NNN
//NND                   .hNNNNNNNNNNB.                    .NNN
//NNs                    (NNNNNNNNNN=                      BNN
//NN<         ...        .DNNNNNNNNN'       '~<+<('        zNN
//NN~       +DBNNh<       (NNNNNNNNh       (NNNNNNN(       =NN
//NB'      +NNNNNNND.     -NNNNNNNNs      (NNNNNNNNN-      <NN
//NB'     .BNNNNNNNN~     'NNNNNNNNs      =NNNNNNNNN<      (NN
//ND.     'NNNNNNNNN<     'NNNNNNNNs      zNNNNNNNNNz      ~NN
//Nh.     (NNNNNNNNN<     -NNNNNNNNh      sNNNNNNNNNB      -NN
//Nh      +NNNNNNNNN~     ~NNNNNNNNB.     (NNNNNNNNNN.     'BN
//Nh      +NNNNNNNND.     <NNNNNNNNN(     'sNNNNNNNNN'     'BN
//Nz      =NNNNNNNN-     .DNNNNNNNNNh      -NNNNNNNNN'     'BN
//Nz      sNNNNNNB(      (NNNNNNNNNNB-      ~BNNNNNNN'     .DN
//Nz      zNNNNND(      .hNNNNNNNNNNNh.      ~DNNNNNN-     .DN
//Ns      sNNNNB'       =NNNNNNNNNNNNN=       -DNNNNN-     .DN
//Ns      +NNN+.       =NNNNNNNNNNNNNNN+       .DNNNN-     .DN
//Ns      'z+'       .+BNNNNNNNNNNNNNNNB+       '+DNB.     .DN
//Ns                'sNNNNNNNNNNNNNNNNNNNs-       .~-      .DN
//Ns                (NNNNNNNNNNNNNNNNNNNNND~               .DN
//Ns                 sNNNNNNNNNNNNNNNNNNNNNNs'             .DN
//Ns                 .BNNNNNNNNNNNNNNNNNNNNNNN(            .DN
//Ns          .      .~NNNNNNNNNNNNNNNNNNNNNNNNz.          .DN
//Ns        'zBB'      =NNNNNNNNNNNNNNNNNNNNNNNND(         .DN
//Ns       -BNNNz.     .hNNNNNNNNNNNNNNNNNNNNNNNNB=.       .DN
//Ns      .BNNNNN+      -NNNNNNNh<~<+NNNh<<sNNN+<zNz       .DN
//Ns      -NNNNNNz       zNNNNB='    (DNs  <NND. <NN-      .DN
//Ns      (NNNNNNB(      (NNNN( .<z-  =Ns  (NNz  +NN(      .DN
//Ns      (NNNNNNNz      .hNND.'sNNN( (ND. 'BN< -BNN<      .DN
//Nz      ~NNNNNNNB.      (NN<.(NNDs. <NN<  -<..hNNN(      'BN
//Nz      -NNNNNNNN<      'NN' '+'   .DNNN-.   (NNNN~      'BN
//Nh      'NNNNNNNND      .DB      '(DNNNNs    =NNNN~      'BN
//Nh      .NNNNNNNNN.      sB   '=DBNNBNNB~  . .hNNN'      -NN
//ND.      BNNNNNNNN-      (N' 'hNNNNNsNN( 'hz' .hNB.      ~NN
//NB'      zNNNNNNNN(      'N=  (zNNB((ND  (NN=  (ND       <NN
//NN'      =NNNNNNNN<      .NB.  .''' =Nz  =NNh. 'B=       =NN
//NN(      (NNNNNNNN+      .BNz'     ~BNs  sNNN'  D~       hNN
//NNh      -NNNNNNNN=      .BNNNDzzhBNNNNBBNNNNBBBN'      'NNN
//NNNDDDhDhDNNNNNNNNBDDDDDDDBNNNNNNNNNNNNNNNNNNNNNNDDDDhDDBNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//
//Draw Map
//
//Modify:Rex9
//
//Function:
//  Create a map using GDI+.
//
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
//NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawMapClass
{
    public class DrawMap : PictureBox
    {
        public struct GoldenSectionST
        {
            public double shortGS;
            public double longGS;


        }
        #region 分割
        public static GoldenSectionST GoldenSection(double len)
        {
            GoldenSectionST p;
            //长的一段

            p.longGS = len * 0.618;
            //短的一段
            p.shortGS = len - p.longGS;
            return p;
        }
        #endregion
        public DrawMap()
        {
            
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            GoldenSectionST gsTop, gsLeft;
            int ledWidth = SystemInformation.VirtualScreen.Width;
            int ledHeight = SystemInformation.VirtualScreen.Height;
            double topOffset = ledHeight;
            double leftOffset = ledWidth;
            for (int i = 0; i < 4; i++)
            {
                gsTop = GoldenSection(topOffset);
                topOffset = gsTop.shortGS;
                gsLeft = GoldenSection(leftOffset);
                leftOffset = gsLeft.shortGS;
            }
            int topO = (int)topOffset;
            int leftO = (int)leftOffset;
            int[,] map ={
                        {0,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0},
                        {1,0,0,0,1,0,1,0,0,0,1,0,1,0,0,0,1,0},
                        {1,0,0,0,1,0,1,1,1,1,0,0,1,1,1,1,0,0},
                        {1,1,1,1,1,0,1,0,0,0,1,0,1,0,0,0,1,0},
                        {1,0,0,0,1,0,1,1,1,1,0,0,1,1,1,1,0,0}
                        };
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    if (map[i, j] == 1)
                    {
                        HatchStyle hs = (HatchStyle)(10 - i);
                        HatchBrush hb = new HatchBrush(hs, Color.Black, Color.Red);
                        Rectangle rtl = new Rectangle(leftO + j * topO, topO + i * topO, topO, topO);
                        pevent.Graphics.FillRectangle(hb, rtl);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            int[,] map1 ={
                        {0,1,1,1,1,0,1,1,1,1,1,0,1,0,0,0,1,0,1,1,1,1,1,0,1,1,1,1,0,0,0,1,1,1,0,0,1,0,0,0,0,0},
                        {1,0,0,0,0,0,1,0,0,0,0,0,1,1,0,0,1,0,1,0,0,0,0,0,1,0,0,0,1,0,1,0,0,0,1,0,1,0,0,0,0,0},
                        {1,0,0,1,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,1,1,1,1,0,1,1,1,1,0,0,1,0,0,0,1,0,1,0,0,0,0,0},
                        {1,0,0,0,1,0,1,0,0,0,0,0,1,0,0,1,1,0,1,0,0,0,0,0,1,0,0,1,0,0,1,1,1,1,1,0,1,0,0,0,0,0},
                        {0,1,1,1,0,0,1,1,1,1,1,0,1,0,0,0,1,0,1,1,1,1,1,0,1,0,0,1,1,0,1,0,0,0,1,0,1,1,1,1,1,0}
                        };
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 42; j++)
                {
                    if (map1[i, j] == 1)
                    {
                        HatchStyle hs = (HatchStyle)(10 - i);
                        HatchBrush hb = new HatchBrush(hs, Color.Black, Color.Red);
                        Rectangle rtl = new Rectangle(leftO + j * (topO / 3), topO + 5 * topO + topO / 3 + i * (topO / 3), topO / 3, topO / 3);
                        pevent.Graphics.FillRectangle(hb, rtl);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            int[,] map2 ={
                        {1,0,0,0,1,0,0,1,1,1,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,1,1,1,1,0,0,1,1,1,0,0,1,1,1,1,0,0},
                        {1,1,0,1,1,0,1,0,0,0,1,0,1,1,0,0,1,0,0,0,1,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,1,0,0,0,1,0},
                        {1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0,0,0,1,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,1,1,1,1,0,0},
                        {1,0,0,0,1,0,1,0,0,0,1,0,1,0,0,1,1,0,0,0,1,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,1,0,0,1,0,0},
                        {1,0,0,0,1,0,0,1,1,1,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,1,0,0,0,0,1,1,1,0,0,1,0,0,1,1,0}
                        };
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 42; j++)
                {
                    if (map2[i, j] == 1)
                    {
                        HatchStyle hs = (HatchStyle)(10 - i);
                        HatchBrush hb = new HatchBrush(hs, Color.Black, Color.Red);
                        Rectangle rtl = new Rectangle(leftO + j * (topO / 3), topO + 5 * topO + 7 * (topO / 3) + i * (topO / 3), topO / 3, topO / 3);
                        pevent.Graphics.FillRectangle(hb, rtl);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
