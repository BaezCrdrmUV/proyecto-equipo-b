-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema Whats_CuentasDeUsuario
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Whats_CuentasDeUsuario
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Whats_CuentasDeUsuario` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `Whats_CuentasDeUsuario` ;

-- -----------------------------------------------------
-- Table `Whats_CuentasDeUsuario`.`Contrasena`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Whats_CuentasDeUsuario`.`Contrasena` (
  `idContrasena` INT NOT NULL AUTO_INCREMENT,
  `contrasena` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`idContrasena`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Whats_CuentasDeUsuario`.`Genero`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Whats_CuentasDeUsuario`.`Genero` (
  `idGenero` INT NOT NULL AUTO_INCREMENT,
  `genero` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idGenero`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Whats_CuentasDeUsuario`.`Cuenta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Whats_CuentasDeUsuario`.`Cuenta` (
  `idCuenta` INT NOT NULL AUTO_INCREMENT,
  `nombreUsuario` VARCHAR(100) NOT NULL,
  `Contrasena_idContrasena` INT NOT NULL,
  `Genero_idGenero` INT NOT NULL,
  `idFotoCuentaUsuario` INT NULL,
  PRIMARY KEY (`idCuenta`),
  INDEX `fk_Cuenta_Contrasena1_idx` (`Contrasena_idContrasena` ASC),
  INDEX `fk_Cuenta_Genero1_idx` (`Genero_idGenero` ASC),
  CONSTRAINT `fk_Cuenta_Contrasena1`
    FOREIGN KEY (`Contrasena_idContrasena`)
    REFERENCES `Whats_CuentasDeUsuario`.`Contrasena` (`idContrasena`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Cuenta_Genero1`
    FOREIGN KEY (`Genero_idGenero`)
    REFERENCES `Whats_CuentasDeUsuario`.`Genero` (`idGenero`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Whats_CuentasDeUsuario`.`Correo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Whats_CuentasDeUsuario`.`Correo` (
  `idCorreo` INT NOT NULL AUTO_INCREMENT,
  `correo` VARCHAR(100) NOT NULL,
  `Cuenta_idCuenta` INT NOT NULL,
  PRIMARY KEY (`idCorreo`),
  INDEX `fk_Correo_Cuenta_idx` (`Cuenta_idCuenta` ASC),
  CONSTRAINT `fk_Correo_Cuenta`
    FOREIGN KEY (`Cuenta_idCuenta`)
    REFERENCES `Whats_CuentasDeUsuario`.`Cuenta` (`idCuenta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Whats_CuentasDeUsuario`.`Telefono`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Whats_CuentasDeUsuario`.`Telefono` (
  `idTelefono` INT NOT NULL AUTO_INCREMENT,
  `telefono` VARCHAR(20) NOT NULL,
  `Cuenta_idCuenta` INT NOT NULL,
  PRIMARY KEY (`idTelefono`),
  INDEX `fk_Telefono_Cuenta1_idx` (`Cuenta_idCuenta` ASC),
  CONSTRAINT `fk_Telefono_Cuenta1`
    FOREIGN KEY (`Cuenta_idCuenta`)
    REFERENCES `Whats_CuentasDeUsuario`.`Cuenta` (`idCuenta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
