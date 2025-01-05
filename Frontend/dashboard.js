document.addEventListener("DOMContentLoaded", function() {
  // Retrieve JWT token from localStorage
  const token = localStorage.getItem('jwtToken');

  // If token exists, include it in the Authorization header
  const headers = token ? {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
  } : {
      'Content-Type': 'application/json'
  };

  // Fetch data from the API
  fetch('https://localhost:7226/Artist', {
      method: 'GET',
      headers: headers // Include the Authorization header if token exists
  })
  .then(response => response.json())
  .then(data => {
      var table = document.getElementById("dashboard");
      table.innerHTML = populateArtists(data); // Assuming this function populates your table
  })
  .catch(error => console.error('Error:', error))
  .finally(() => {
      addEventHandlers(); // Assuming this adds event handlers to elements
  });
});

function populateArtists(data) {
    var result = "";
    data.forEach(element => {
        result += `<tr class='table-row'>
        <td>
          <img id='arrowOpen' data-toggle='collapse' data-target='.row` + element.id + `-details' aria-expanded='false' height='30px' src='img/arrowclosed.png' alt='Closed arrow'>
          <img id='arrowClosed' class='hide' data-toggle='collapse' data-target='.row` + element.id + `-details' width='30px' height='30px' src='img/arrowopen.png' alt='Open arrow'>
        </td>
        <td>` + element.name + `</td>
        <td><a href='artist.html?id=` + element.id + `'><button>Edit</button></a></td>
        <td><button onclick='deleteArtist(` + element.id + `)'>Delete</button></td>
      </tr>
      <tr id='artistDetails' class='details-row row` + element.id + `-details artistInspection collapse'>
        <td colspan='4'>
          <div>
            <p>Additional details for John Doe</p>
            <p>More data goes here...</p>
          </div>
        </td>
      </tr>`
    });
    return result
}

function addEventHandlers() {
	$('#artistDetails').on('show.bs.collapse', function () {
		var arrowOpen = document.getElementById("arrowOpen");
		var arrowClosed = document.getElementById("arrowClosed");
		arrowOpen.classList.add("hide");
		arrowClosed.classList.remove("hide");
	})

	$('#artistDetails').on('hidden.bs.collapse', function () {
		var arrowOpen = document.getElementById("arrowOpen");
		var arrowClosed = document.getElementById("arrowClosed");
		arrowOpen.classList.remove("hide");
		arrowClosed.classList.add("hide");
	})
}

function navigateToAddArtist() {
  window.location.href = "add-artist.html"; // Navigate to the Add Artist page
}

async function deleteArtist(id) {
  // Retrieve JWT token from localStorage
  const token = localStorage.getItem('jwtToken');

  // Prepare headers with the Authorization token if it exists
  const headers = token ? {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
  } : {
      'Content-Type': 'application/json'
  };

  // Send the DELETE request with the token in the headers
  await fetch(`https://localhost:7226/Artist?id=${id}`, {
      method: "DELETE",
      headers: headers  // Include Authorization header if token exists
  })
  .then(response => {
      if (!response.ok) {
          throw new Error('Failed to delete artist');
      }
      location.reload(); // Reload page after successful delete
  })
  .catch(error => {
      console.error('Error:', error);
      alert('Error deleting artist.');
  });
}

function logout() {
  // Remove JWT token from localStorage
  localStorage.removeItem('jwtToken');
  
  // Redirect to login page
  window.location.href = "login.html";
}