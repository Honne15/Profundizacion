import { useState } from "react";
import "./App.css";

function App() {
  const [writeTask, setWriteTask] = useState("");
  const [listOfTask, setListOfTask] = useState([]);

  const create = () => {
    if (writeTask.trim() === "") {
      alert("No puedes agregar una tarea vacía");
      return;
    }

    const newTask = { text: writeTask, completed: false };
    setListOfTask([...listOfTask, { text: writeTask, completed: false }]);
    setWriteTask("");
  };

  const removeTask = (index) => {
    setListOfTask(listOfTask.filter((_, i) => i !== index));
  };

  const toggleComplete = (index) => {
    setListOfTask(
      listOfTask.map((task, i) =>
        i === index ? { ...task, completed: !task.completed } : task
      )
    );
  };

  return (
    <>
      <div className="container">
        <h1>Lista de tareas</h1>

        <input
          type="text"
          value={writeTask}
          onChange={(e) => setWriteTask(e.target.value)}
          placeholder="Escribe una tarea..."
        />

        <button type="button" onClick={create}>
          Agregar
        </button>

        <ul>
          {listOfTask.map((task, index) => (
            <li
              key={index}
              className={task.completed ? "completed" : ""}
              onClick={() => toggleComplete(index)}
            >
              {task.text}
              <button
                onClick={(e) => {
                  e.stopPropagation();
                  removeTask(index);
                }}
              >
                X
              </button>
            </li>
          ))}
        </ul>
      </div>
    </>
  );
}

export default App;