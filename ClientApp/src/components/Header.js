import React from 'react';
import './Header.css';
import logo from '../assets/logo.svg';
export default function Header() {
  return (
      <header>
          <img src={logo} width="48px" height="48px" alt="Alura Logo" />
          <h1>Challenge ONE - Encriptador de texto</h1>
      </header>
  );
}