const queryString = window.location.search;
const id = queryString.split('=')[1];

document.addEventListener("DOMContentLoaded", function() {
    // Retrieve JWT token from localStorage
    const token = localStorage.getItem('jwtToken');

    // Prepare headers with Authorization token if it exists
    const headers = token ? {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
    } : {
        'Content-Type': 'application/json'
    };

    // Fetch the artist data using the ID
    fetch('https://localhost:7226/Artist/' + id, {
        method: 'GET',
        headers: headers // Include the Authorization header if token exists
    })
    .then(response => response.json())
    .then(data => {
        var name = document.getElementById("name");
        name.innerHTML = data.name;  // Populate the artist name in the page
    })
    .catch(error => console.error('Error:', error));
});

function updateArtist() {
    // Prepare the body with the updated artist information
    var body = {
        "Id": id, 
        "Name": document.getElementById("nameField").value
    };

    // Retrieve the JWT token from localStorage
    const token = localStorage.getItem('jwtToken');

    // Prepare the headers with the Authorization token if it exists
    const headers = token ? {
        "Authorization": `Bearer ${token}`,
        "Content-Type": "application/json"
    } : {
        "Content-Type": "application/json"
    };

    // Send the PUT request to update the artist
    fetch("https://localhost:7226/Artist", {
        method: "PUT",
        headers: headers,  // Include Authorization header if token exists
        body: JSON.stringify(body)
    })      
    .then(response => response.json())
    .then(_ => {
        location.reload();  // Reload the page after successful update
    })
    .catch(error => console.error('Error:', error));
}