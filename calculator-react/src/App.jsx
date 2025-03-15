import {useState } from "react";
import "./App.css";

function App() {
  let title = "¡Bienvenido a la calculadora con React!";
  let [num1, setNum1] = useState(0);
  let [num2, setNum2] = useState(0);
  const [operacion, setOperacion] = useState("");

  const calcular = () => {

    if (operacion == "sumar") {
      let suma = num1 + num2;
      alert("El resultado de la suma es: " + suma);
    } else if (operacion == "restar") {
      let resta = num1 - num2;
      alert("El resultado de la resta es: " + resta);
    } else if (operacion == "multiplicar") {
      let multiplicar = num1 * num2;
      alert("El resultado de la multiplicación es: " + multiplicar);
    } else if (operacion == "dividir") {
      if (num2 !== 0) {
        let dividir = num1 / num2;
        alert("El resultado de la división es: " + dividir);
      } else {
        alert("No se puede dividir entre 0");
      }
    } else if (operacion == "potencia") {
      let potencia = Math.pow(num1, num2);
      alert("El resultado de la potencia es: " + potencia);
    } else if (operacion == "raiz") {
      let raiz = Math.sqrt(num1);
      alert("El resultado de la raíz es: " + raiz);
    } else {
      alert("Operación no válida");
    }
  };

  return (
    <>
      <div>
        <h1>{title}</h1>

        <select name="operacion" onChange={(e) => setOperacion(e.target.value)}>
          <option>Elige la operación</option>
          <option value="sumar">Sumar</option>
          <option value="restar">Restar</option>
          <option value="multiplicar">Multiplicar</option>
          <option value="dividir">Dividir</option>
          <option value="potencia">Potencia</option>
          <option value="raiz">Raiz Cuadrada</option>
        </select>
        <input
          type="number"
          name="numero1"
          value={num1}
          onChange={(e) => setNum1(parseFloat(e.target.value))}
        />
        <input
          type="number"
          name="numero2"
          value={num2}
          onChange={(e) => setNum2(parseFloat(e.target.value))}
        />
        <button type="button" id="calcular" onClick={calcular}>
          Calcular
        </button>
      </div>
    </>
  );
}

export default App;
