using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimerParcial;
using System;

namespace GestionEmpleados.Test
{
    [TestClass]
    public class EmpleadosTest
    {
        [TestMethod]
        public void OperadorIgual_DeberiaRetornarTrue_CuandoEmpleadosSonIgualesPorNombreYTurno()
        {
            // Arrange
            Mesero empleadoUno = new Mesero("Juan", 1111, ETurnos.MañanaPartTime, "Patio", 4);
            Mesero empleadoDos = new Mesero("Juan", 2222, ETurnos.MañanaPartTime, "Principal", 10);

            //Act y Assert
            Assert.AreEqual(empleadoUno, empleadoDos);
        }

        [TestMethod]
        public void OperadorIgual_DeberiaRetornarTrue_CuandoEmpleadosSonIgualesPorLegajo()
        {
            // Arrange
            Mesero empleadoUno = new Mesero("Juan", 1111, ETurnos.MañanaPartTime, "Patio", 4);
            Mesero empleadoDos = new Mesero("Laura", 1111, ETurnos.NochePartTime, "Patio", 4);

            //Act y Assert
            Assert.AreEqual(empleadoUno, empleadoDos);
        }

        [TestMethod]
        public void OperadorIgual_DeberiaRetornarFalse_CuandoEmpleadosSonDistintosPorNombreYTurnoOLegajo()
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
        public void ConversionImplicitaString_DeberiaRetornarNombreCorrecto()
        {
            // Arrange
            Cajero empleado = new Cajero("Franco", 1234, ETurnos.TardePartTime, 0, 1);

            // Act
            string nombre = empleado;

            // Assert
            Assert.AreEqual("Franco", nombre);
        }

        [TestMethod]
        public void ConversionImplicitaInt_DeberiaRetornarLegajoCorrecto()
        {
            // Arrange
            Cajero empleado = new Cajero("Franco", 1234, ETurnos.TardePartTime, 0, 1);

            // Act
            int legajo = empleado;

            // Assert
            Assert.AreEqual(1234, legajo);
        }

        [TestMethod]
        public void ConversionImplicitaETurnos_DeberiaRetornarTurnoCorrecto()
        {
            // Arrange
            Cajero empleado = new Cajero("Franco", 1234, ETurnos.TardePartTime, 0, 1);

            // Act
            ETurnos turno = empleado;

            // Assert
            Assert.AreEqual(ETurnos.TardePartTime, turno);
        }

    }
}
