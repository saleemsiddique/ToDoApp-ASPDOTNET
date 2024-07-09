function clearModal() {
    document.getElementById('taskForm').reset();
    document.getElementById('taskModalLabel').innerText = 'Crear Nueva Tarea';
    document.getElementById('submitButton').innerText = 'Crear';
    document.getElementById('taskForm').setAttribute('action', '/ToDoScreen?handler=CrearTarea'); // Ruta para crear una nueva tarea
    document.getElementById('taskId').value = '';
}

function editTask(id, title, description) {
    document.getElementById('taskModalLabel').innerText = 'Editar Tarea';
    document.getElementById('submitButton').innerText = 'Guardar';
    document.getElementById('titulo').value = title;
    document.getElementById('descripcion').value = description;
    document.getElementById('taskForm').setAttribute('action', `/ToDoScreen?handler=EditarTarea&id=${id}`); // Ruta para editar la tarea
    document.getElementById('taskId').value = id;
}