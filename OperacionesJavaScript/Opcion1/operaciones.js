document.getElementById("sumar").addEventListener("click", function() {
    let num1 = parseInt(document.getElementById("sum1").value);
    let num2 = parseInt(document.getElementById("sum2").value);

    let suma = num1 + num2;

    alert("El resultado de la suma es: " + suma);
});

document.getElementById("restar").addEventListener("click", function() {
    let num1 = parseInt(document.getElementById("rest1").value);
    let num2 = parseInt(document.getElementById("rest2").value);

    let resta = num1 - num2;

    alert("El resultado de la resta es: " + resta);
});

document.getElementById("multiplicar").addEventListener("click", function() {
    let num1 = parseInt(document.getElementById("mult1").value);
    let num2 = parseInt(document.getElementById("mult2").value);

    let multiplicar = num1 * num2;

    alert("El resultado de la multiplicación es: " + multiplicar);
});

document.getElementById("dividir").addEventListener("click", function() {
    let num1 = parseInt(document.getElementById("div1").value);
    let num2 = parseInt(document.getElementById("div2").value);

    let dividir = num1 / num2;

    alert("El resultado de la división es: " + dividir);
});

document.getElementById("potencia").addEventListener("click", function() {
    let num1 = parseInt(document.getElementById("pot1").value);
    let num2 = parseInt(document.getElementById("pot2").value);

    let potencia = Math.pow(num1, num2);

    alert("El resultado de la potencia es: " + potencia);
});

document.getElementById("raiz").addEventListener("click", function() {
    let num1 = parseInt(document.getElementById("raiz1").value);
    let num2 = parseInt(document.getElementById("raiz2").value);

    let raiz = Math.sqrt(num1);

    alert("El resultado de la raiz Cuadrada es: " + raiz);
});