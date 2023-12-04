const queryString = window.location.search;
const id = queryString.split('=')[1];

document.addEventListener("DOMContentLoaded", function() {
    fetch('https://localhost:7226/Artist/' + id)
      .then(response => response.json())
      .then(data => {
        var name = document.getElementById("name");
        name.innerHTML = data.name;    
    })
      .catch(error => console.error('Error:', error))
});

function updateArtist() {
    var body = {"Id": id, "Name": document.getElementById("nameField").value};
    fetch("https://localhost:7226/Artist", {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(body)
    })      
    .then(response => response.json())
    .then(_ => {
        location.reload();
    })
    .catch(error => console.error('Error:', error));
}