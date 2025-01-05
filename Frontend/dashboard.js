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
  .then(async data => {
      var table = document.getElementById("dashboard");
      table.innerHTML = await populateArtists(data); // Ensure the HTML is generated after all fetches complete
  })
  .catch(error => console.error('Error:', error))
  .finally(() => {
      addEventHandlers(); // Assuming this adds event handlers to elements
  });
});

async function fetchSinglesForArtist(artistId) {
  // Retrieve JWT token from localStorage
  const token = localStorage.getItem('jwtToken');

  // If token exists, include it in the Authorization header
  const headers = token ? {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
  } : {
      'Content-Type': 'application/json'
  };

  try {
    const response = await fetch(`https://localhost:7226/single/byArtist/${artistId}`, {
        method: 'GET',
        headers: headers
    });

    return await response.json();
  } catch (error) {
    console.error('Error fetching singles for artist:', error);
    return []; // Return an empty array in case of error
  }
}

async function populateArtists(data) {
  let result = "";

  // Use async/await to handle asynchronous fetching of singles for each artist
  for (const element of data) {
      // Fetch the singles for this artist
      const singles = await fetchSinglesForArtist(element.id);

      // Check if there are any singles
      let artistDetails;
      if (singles.length > 0) {
          // Map the singles to table rows if there are any
          artistDetails = singles.map(single => `
            <tr id='artistDetails${element.id}' class='details-row row${element.id}-details artistInspection collapse'>
                <td></td>
                <td>
                    <p> ${single.title} - ${single.playlength}</p>
                </td>
                <td>
                    <p><strong>Status:</strong> ${single.status}</p>
                </td>
                <td>
                    <button onclick="editSingle(${single.id}, ${element.id})">Edit Single</button>
                </td>
            </tr>

        `).join('');
      } else {
          // If there are no singles, display a message
          artistDetails = `
              <tr id='artistDetails${element.id}' class='details-row row${element.id}-details artistInspection collapse'>
                  <td colspan='4'>
                      <div>
                          <p>No singles available for this artist.</p>
                      </div>
                  </td>
              </tr>`;
      }

      // Add the main artist row with the details and controls for collapsing
      result += `
      <tr class='table-row'>
          <td>
              <img id='arrowOpen' data-toggle='collapse' data-target='.row${element.id}-details' aria-expanded='false' height='30px' src='img/arrowclosed.png' alt='Closed arrow'>
              <img id='arrowClosed' class='hide' data-toggle='collapse' data-target='.row${element.id}-details' width='30px' height='30px' src='img/arrowopen.png' alt='Open arrow'>
          </td>
          <td>${element.name}</td>
          <td><a href='artist.html?id=${element.id}'><button>Edit</button></a></td>
          <td><button onclick='deleteArtist(${element.id})'>Delete</button></td>
      </tr>

      ${artistDetails}

      <tr class='row${element.id}-details artistInspection collapse'>
          <td colspan="4" style="text-align: center;">
              <button onclick="addSingle(${element.id})">Add Singles</button>
          </td>
      </tr>`;
  }

  return result;
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

function navigateToAddPlatform() {
  window.location.href = 'add-platform.html'; // Redirect to add-platform.html
}

function addSingle(artistId) {
  window.location.href = `add-single.html?artistId=${artistId}`;
}

function editSingle(singleId, artistId) {
  window.location.href = `edit-single.html?artistId=${artistId}&singleId=${singleId}`;
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