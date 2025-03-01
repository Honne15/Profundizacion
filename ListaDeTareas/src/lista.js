document.getElementById('create').addEventListener('click', function() {
    const writeTask = document.getElementById('writeTask');
    const listOfTask = document.getElementById('listOfTask');

    if (writeTask.value === "") {
         return alert("No puedes agregar una tarea vacía");
    } else {
        const newTask = document.createElement('li');
        newTask.innerHTML = `${writeTask.value} <button onclick="this.parentElement.remove()">X</button>`;

        newTask.addEventListener("click", function(e) {
            e.target.classList.toggle("completed");
        });
        
        listOfTask.appendChild(newTask);

        writeTask.value = "";
    }
});