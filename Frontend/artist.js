const queryString = window.location.search;
var id = queryString.split('=')[0];
document.addEventListener("DOMContentLoaded", function() {
    fetch('https://localhost:7226/Artist/' + id)
      .then(response => response.json())
      .then(data => {
        var name = document.getElementById("name");
        name.innerHTML = data[0].name;    
    })
      .catch(error => console.error('Error:', error))
});