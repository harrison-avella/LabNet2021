namespace PooLabTransporte
{
    public abstract class Transporte
    {
        private int pasajeros;

        public Transporte(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }

        public int Pasajeros
        {
            get
            {
                return this.pasajeros;
            }
        }

        public abstract void Avanzar();
        public abstract void Detenerse();

    }
}
