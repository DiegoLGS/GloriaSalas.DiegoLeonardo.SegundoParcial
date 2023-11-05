using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimerParcial;
using System;

namespace GestionEmpleados.Test
{
    [TestClass]
    public class EmpleadosTest
    {
        [TestMethod]
        public void OperadorIgualDeberiaRetornarTrueCuandoEmpleadosSonIgualesPorNombreYTurno()
        {
            // Arrange
            Mesero empleadoUno = new Mesero("Juan", 1111, ETurnos.MañanaPartTime, "Patio", 4);
            Mesero empleadoDos = new Mesero("Juan", 2222, ETurnos.MañanaPartTime, "Principal", 10);

            //Act y Assert
            Assert.AreEqual(empleadoUno, empleadoDos);
        }

        [TestMethod]
        public void OperadorIgualDeberiaRetornarTrueCuandoEmpleadosSonIgualesPorLegajo()
        {
            // Arrange
            Mesero empleadoUno = new Mesero("Juan", 1111, ETurnos.MañanaPartTime, "Patio", 4);
            Mesero empleadoDos = new Mesero("Laura", 1111, ETurnos.NochePartTime, "Patio", 4);

            //Act y Assert
            Assert.AreEqual(empleadoUno, empleadoDos);
        }

        [TestMethod]
        public void OperadorIgualDeberiaRetornarFalseCuandoEmpleadosSonDistintosPorNombreYTurnoOLegajo()
        {
            // Arrange
            Mesero empleadoUno = new Mesero("Juan", 1111, ETurnos.MañanaPartTime, "Principal", 10);
            Mesero empleadoDos = new Mesero("Fernando", 2222, ETurnos.MañanaPartTime, "Principal", 10);
            Mesero empleadoTres = new Mesero("Leo", 3333, ETurnos.MañanaPartTime, "Segundo piso", 3);
            Mesero empleadoCuatro = new Mesero("Leo", 4444, ETurnos.TardeFullTime, "Segundo piso", 3);

            //Act y Assert
            Assert.AreNotEqual(empleadoUno, empleadoDos);
            Assert.AreNotEqual(empleadoTres, empleadoCuatro);
        }

        [TestMethod]
        public void ConversionImplicitaStringDeberiaRetornarNombreCorrecto()
        {
            // Arrange
            Cajero empleado = new Cajero("Franco", 1234, ETurnos.TardePartTime, 0, 1);

            // Act
            string nombre = empleado;

            // Assert
            Assert.AreEqual("Franco", nombre);
        }

        [TestMethod]
        public void ConversionImplicitaIntDeberiaRetornarLegajoCorrecto()
        {
            // Arrange
            Cajero empleado = new Cajero("Franco", 1234, ETurnos.TardePartTime, 0, 1);

            // Act
            int legajo = empleado;

            // Assert
            Assert.AreEqual(1234, legajo);
        }

        [TestMethod]
        public void ConversionImplicitaETurnosDeberiaRetornarTurnoCorrecto()
        {
            // Arrange
            Cajero empleado = new Cajero("Franco", 1234, ETurnos.TardePartTime, 0, 1);

            // Act
            ETurnos turno = empleado;

            // Assert
            Assert.AreEqual(ETurnos.TardePartTime, turno);
        }

        [TestMethod]
        public void EmpleadoDeberiaIniciarDisponibilidadHorasExtrasTrue()
        {
            // Arrange
            Cocinero empleado = new Cocinero("Carlos", 1001, ETurnos.TardeFullTime, "Pastas", "Chef Especialidad Italiana");

            // Act
            bool disponibilidadHorasExtras = empleado.DisponibleHorasExtras;

            // Assert
            Assert.IsTrue(disponibilidadHorasExtras);
        }

        [TestMethod]
        public void EmpleadoCambiarDisponibilidadHorasExtrasDeberiaCambiarAFalse()
        {
            // Arrange
            Cocinero empleado = new Cocinero("Lucía", 1020, ETurnos.MañanaPartTime, "Reposteria", "Maestra Patissier");

            // Act
            empleado.CambiarDisponibilidadHorasExtras();

            // Assert
            Assert.IsFalse(empleado.DisponibleHorasExtras);
        }
    }
}
