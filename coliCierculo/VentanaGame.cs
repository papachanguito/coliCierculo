﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace coliCierculo
{
    class VentanaGame:GameWindow
    {
        Cuadro player1 = new Cuadro();
        Cuadro player2 = new Cuadro();
        Cuadro obstacle = new Cuadro();

        circulo bola = new circulo();

        punto uno = new punto(5,5,0);
        punto p1One = new punto(7, 2, 1);
        punto p1Two = new punto(1, 1, 1);
        
        
        
        punto p2One = new punto(7, 7, 1);
        punto p2Two = new punto(1, 8, 1);

        punto obsOne = new punto(5,5,1);
        punto obsTwo = new punto(4,4,1);
        
        punto color = new punto(0,0,0);
        Colision col = new Colision();

       
        bool players=true;
        double r = 0.1;

   

        public VentanaGame(int ancho, int alto)
            : base(ancho, alto)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.LoadIdentity();
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(0, 10, 0, 10, -1, 1);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(0.5f, 0.5f, 1f, 1f);

        }

        

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);



            if (!players)
            {
                if (!col.checarcolision(player1, bola))
                {
                    uno.x -= 0.1;

                }
                else
                    players = true;
              }
           
           if (players)
            {
                if (!col.checarcolision(player2, bola))
                {
                    uno.x += 0.1;

                }
                else
                    players = false;
            }


            
            
            //col.playersCol(player1, player2, bola);

            bola.dibuja(uno, r, color);
            player1.Imprime(p1One,p1Two);
            player2.Imprime(p2One, p2Two);
            obstacle.Imprime(obsOne, obsTwo);

            this.SwapBuffers();
        }

        
    }
}
