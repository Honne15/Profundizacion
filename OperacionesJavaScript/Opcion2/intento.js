document.getElementById("calcular").addEventListener("click", function() {
    let num1 = parseInt(document.getElementById("numero1").value);
    let num2 = parseInt(document.getElementById("numero2").value);
    let operacion = document.getElementById("operacion").value;

    if(operacion == "sumar"){
        let suma = num1 + num2;
        alert("El resultado de la suma es: " + suma);
    } else if (operacion== "restar"){
        let resta = num1 - num2;
        alert("El resultado de la resta es: " + resta);
    } else if (operacion == "multiplicar"){
        let multiplicar = num1 * num2;
        alert("El resultado de la multiplicación es: " + multiplicar);
    } else if (operacion == "dividir"){
        if(num2 !== 0){
            let dividir = num1 / num2;
            alert("El resultado de la división es: " + dividir);
        } else {
            alert("No se puede dividir entre 0");
        }
    } else if (operacion == "potencia"){
        let potencia = Math.pow(num1, num2);
        alert("El resultado de la potencia es: " + potencia);
    } else if (operacion == "raiz") {
        let raiz = Math.sqrt(num1);
        alert("El resultado de la raíz es: " + raiz);
    } else {
        alert("Operación no válida");
    }
});