document.addEventListener("DOMContentLoaded", function () {

    const apiUrl = 'http://localhost:5231';  // Cambia esto por la URL de tu API
  
    // Obtener todos los colaboradores
    document.getElementById('getAllColaboradores').addEventListener('click', () => {
      fetch(`${apiUrl}/Colaborador`)
        .then(response => response.json())
        .then(data => {
          const list = document.getElementById('colaboradorList');
          list.innerHTML = data.length ? 
            data.map(colaborador => `ID: ${colaborador.id}, Nombre: ${colaborador.nombre}`).join('<br>') : 
            "No se encontraron colaboradores.";
        })
        .catch(error => {
          console.error('Error:', error);
          document.getElementById('colaboradorList').innerHTML = "Error al obtener los colaboradores.";
        });
    });
  
    // Crear un colaborador
    document.getElementById('createColaborador').addEventListener('click', () => {
      const nombre = document.getElementById('colaboradorNombre').value;
  
      if (nombre) {
        const payload = { nombre };
  
        fetch(`${apiUrl}/Colaborador`, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(payload)
        })
          .then(response => response.json())
          .then(data => {
            const result = document.getElementById('createResult');
            result.innerHTML = `Colaborador creado:\nID: ${data.id}, Nombre: ${data.nombre}`;
          })
          .catch(error => {
            console.error('Error:', error);
            document.getElementById('createResult').innerHTML = "Error al crear el colaborador.";
          });
      } else {
        alert("Por favor ingresa un nombre.");
      }
    });
  
    // Obtener un colaborador por ID
    document.getElementById('getColaboradorById').addEventListener('click', () => {
      const id = document.getElementById('colaboradorId').value;
  
      if (id) {
        fetch(`${apiUrl}/Colaborador/${id}`)
          .then(response => response.json())
          .then(data => {
            const detail = document.getElementById('colaboradorDetail');
            detail.innerHTML = data ? 
              `ID: ${data.id}, Nombre: ${data.nombre}` : 
              "No se encontró el colaborador con ese ID.";
          })
          .catch(error => {
            console.error('Error:', error);
            document.getElementById('colaboradorDetail').innerHTML = "Error al obtener el colaborador.";
          });
      } else {
        alert("Por favor ingresa un ID.");
      }
    });
  
  });
  