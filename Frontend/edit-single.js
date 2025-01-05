document.addEventListener("DOMContentLoaded", function () {
    // Retrieve the single ID and artist ID from URL parameters
    const urlParams = new URLSearchParams(window.location.search);
    const singleId = parseInt(urlParams.get("singleId"));
    const artistId = parseInt(urlParams.get("artistId"));
  
    // Fetch platform options
    fetchPlatforms();
  
    // Fetch the single details and populate the form
    if (singleId) {
      fetchSingleDetails(singleId);
    }
  
    // Handle form submission
    const form = document.getElementById("editSingleForm");
    form.addEventListener("submit", function (event) {
      event.preventDefault();
  
      // Get selected platform IDs
      const selectedPlatforms = Array.from(document.getElementById("platform").selectedOptions)
        .map(option => parseInt(option.value));
  
      const formData = {
        id: singleId,
        title: document.getElementById("title").value,
        status: document.getElementById("status").value,
        playlength: document.getElementById("playlength").value,
        cover: document.getElementById("cover").value,
        platformIds: selectedPlatforms, // Pass the list of selected platform IDs
        artistid: artistId,
      };
  
      // Call API to update single
      updateSingle(formData);
    });
  });
  
  // Fetch the platform options and populate the dropdown
  function fetchPlatforms() {
    const token = localStorage.getItem("jwtToken");
    const headers = token
      ? {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json",
        }
      : {
          "Content-Type": "application/json",
        };
  
    fetch("https://localhost:7226/Platform", {
      method: "GET",
      headers: headers,
    })
      .then((response) => response.json())
      .then((platforms) => {
        const platformSelect = document.getElementById("platform");
        platformSelect.innerHTML = ""; // Clear existing options
  
        // Populate platform options
        platforms.forEach((platform) => {
          const option = document.createElement("option");
          option.value = platform.id;
          option.textContent = platform.name;
          platformSelect.appendChild(option);
        });
      })
      .catch((error) => console.error("Error fetching platforms:", error));
  }
  
  // Fetch the details of the single to edit and populate the form fields
  function fetchSingleDetails(singleId) {
    const token = localStorage.getItem("jwtToken");
    const headers = token
      ? {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json",
        }
      : {
          "Content-Type": "application/json",
        };
  
    fetch(`https://localhost:7226/single/${singleId}`, {
      method: "GET",
      headers: headers,
    })
      .then((response) => response.json())
      .then((single) => {
        // Populate the form fields with the existing single's properties
        document.getElementById("title").value = single.title;
        document.getElementById("status").value = single.status;
        document.getElementById("playlength").value = single.playlength;
        document.getElementById("cover").value = single.cover;
  
        // Set the selected platforms
        if (single.platformIds) {
          const platformSelect = document.getElementById("platform");
          single.platformIds.forEach((id) => {
            const option = platformSelect.querySelector(`option[value="${id}"]`);
            if (option) {
              option.selected = true;
            }
          });
        }
      })
      .catch((error) => console.error("Error fetching single details:", error));
  }
  
  // Update the single details via API
  function updateSingle(data) {
    const token = localStorage.getItem("jwtToken");
    const headers = token
      ? {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json",
        }
      : {
          "Content-Type": "application/json",
        };
  
    fetch(`https://localhost:7226/single`, {
      method: "PUT",
      headers: headers,
      body: JSON.stringify(data),
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error("Failed to edit single");
        }
        return response.json();
      })
      .then((result) => {
        document.getElementById("message").textContent = "Single updated successfully!";
  
        // Redirect back to dashboard after a short delay
        setTimeout(() => {
          window.location.href = "dashboard.html";
        }, 2000);
      })
      .catch((error) => {
        console.error("Error updating single:", error);
        document.getElementById("message").textContent = "Error updating single. Please try again.";
      });
  }
  