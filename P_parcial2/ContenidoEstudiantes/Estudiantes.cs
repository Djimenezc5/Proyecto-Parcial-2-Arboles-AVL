using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_parcial2.Contenido_Arboles;

namespace P_parcial2.ContenidoEstudiantes
{
    class Estudiantes : Comparador
    {
        public string apellidos { get; set; }
        public string nombre { get; set; }
        public string Email { get; set; }
        public int IdEst { get; set; }
        public int Lab1 { get; set; }
        public int Lab2 { get; set; }
        public int Lab3 { get; set; }
        public int Lab4 { get; set; }
        public int repeticion { get; set; }


        public Estudiantes()
        {

        }

        public Estudiantes(string ape, string nom, string email, int Id, int L1, int L2, int L3, int L4)
        {
            this.apellidos = ape;
            this.nombre = nom;
            this.IdEst = Id;
            this.Email = email;
            this.Lab1 = L1;
            this.Lab2 = L2;
            this.Lab3 = L3;
            this.Lab4 = L4;
        }

        public bool igualQue(object q, int c)
        {
            Estudiantes Paux = (Estudiantes)q;
            if (Email.CompareTo(Paux.Email) == 0)
            {
                Paux.repeticion = c;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool menorQue(object q)
        {
            Estudiantes Paux = (Estudiantes)q;

            if (IdEst == 0)
            {
                if (Email.CompareTo(Paux.Email) < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return IdEst < Paux.IdEst;
            
        }

        public bool menorIgualQue(object q)
        {
            Estudiantes Paux = (Estudiantes)q;
            if (Email.CompareTo(Paux.Email) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool mayorQue(object q)
        {
            Estudiantes Paux = (Estudiantes)q;
            if (IdEst == 0)
            {
                if (Email.CompareTo(Paux.Email) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return IdEst > Paux.IdEst;
        }

        public bool mayorIgualQue(object q)
        {
            Estudiantes Paux = (Estudiantes)q;
            if (Email.CompareTo(Paux.Email) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "(" + IdEst + " --> " + nombre + " --> " + apellidos + ")" + ";";
        }
    }
}
