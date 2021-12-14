// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let del_buttons = document.getElementsByClassName('delete-client');
Array.prototype.forEach.call(del_buttons, btn => btn.addEventListener('click', (event) => {
    deleteClient(event.target.dataset.id);
}));


deleteClient = (id) => {
    fetch("controlador/eliminar/" + id, {
        method: "DELETE",
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })
    .then(response => {
        if (response.ok) {
            location.reload();
        }
        else {
            alert("No se pudo eliminar el elemento");
        }
    })
}