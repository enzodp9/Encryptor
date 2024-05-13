import React, { useState } from 'react';
import './Encryptor.css';
import notfound from '../assets/notfound.svg';

const Encryptor = () => {
    const [input, setInput] = useState({
        encryptorName: '',
        text: '',
        key: ''
    });
    const [output, setOutput] = useState('');

    const handleEncrypt = async (e) => {
        if (validateInput()) {
            e.preventDefault();
            const response = await fetch(`/Encryptor/encrypt?encryptorName=${input.encryptorName}&text=${input.text}&key=${input.key}`);
            const data = await response.text();
            setOutput(data);
            console.log(output);
        }
    }

    const handleDecrypt = async (e) => {
        if (validateInput()) {
            e.preventDefault();
            const response = await fetch(`/Encryptor/decrypt?encryptorName=${input.encryptorName}&text=${input.text}&key=${input.key}`);
            const data = await response.text();
            setOutput(data);
            console.log(output);
        }
    }

    const onChange = (e) => {
        const { name, value } = e.target;
        setInput({ ...input, [name]: value });
        console.log(input)
    }

    const validateInput = () => {
        if (input.encryptorName === 'Cesar' && isNaN(parseInt(input.key))) { alert("La clave del cifrado cesar debe ser un numero"); return false }
        if (input.encryptorName === 'AES' && input.key.length !== 16) { alert("La clave del cifrado AES debe tener 16 caracteres"); return false }
        if (input.encryptorName === 'DES' && input.key.length !== 8) { alert("La clave del cifrado DES debe tener 8 caracteres"); return false }
        if (input.encryptorName === 'TDES' && input.key.length !== 24) { alert("La clave del cifrado Triple DES debe tener 24 caracteres"); return false }
        return true
    }

    return (
        <div id="container">
            <div id="left-container">
                <select id="encryption-algorithm" name="encryptorName" onChange={onChange} value={input.encryptorName}>
                    <option value="Null" defaultValue>Seleccione el algoritmo</option>
                    <option value="Cesar">Cifrado Cesar</option>
                    <option value="AES">Cifrado AES</option>
                    <option value="DES">Cifrado DES</option>
                    <option value="TDES">Cifrado Triple DES</option>
                </select>
                <textarea id="input-area" name="text" rows="10" cols="30" placeholder="Ingrese el texto aqui" onChange={onChange} value={input.text}></textarea>
                <input id="key" type="text" name="key" placeholder="Ingrese la clave" onChange={onChange} value={input.key} />
                <div id="buttons">
                    <button id="encrypt" type="submit" onClick={(e) => handleEncrypt(e)}>Encriptar</button>
                    <button id="decrypt" type="submit" onClick={(e) => handleDecrypt(e)}>Desencriptar</button>
                </div>
            </div>
            <div id="right-container">
                {output === '' ?
                    <div id="output-area">
                        <img src={notfound} alt="Not found" />
                        <h1>Ningun mensaje fue encontrado</h1>
                        <p>Ingresa el texto que deseas encriptar o desencriptar</p>
                    </div>
                    :
                    <div id="output-area">
                        <p>{output}</p>
                    </div>
                }
            </div>
        </div>
    );
}

export default Encryptor;
