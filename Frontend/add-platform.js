document.addEventListener('DOMContentLoaded', function () {
    // Handle form submission
    const form = document.getElementById('addPlatformForm');
    form.addEventListener('submit', function (event) {
      event.preventDefault();
  
      const platformData = {
        name: document.getElementById('platformName').value
      };
  
      // Add the platform
      addPlatform(platformData);
    });
  });
  
  // Function to send platform data to the API
  async function addPlatform(data) {
    try {
      const token = localStorage.getItem('jwtToken');
      const headers = token ? {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
      } : {
        'Content-Type': 'application/json'
      };
  
      // Send POST request to add platform
      const response = await fetch('https://localhost:7226/Platform', {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(data)
      });
  
      if (!response.ok) {
        throw new Error('Failed to add platform');
      }
  
      document.getElementById('message').textContent = 'Platform added successfully!';
  
      // Redirect back to dashboard after successful add
      setTimeout(() => {
        window.location.href = 'dashboard.html';
      }, 2000);
  
    } catch (error) {
      console.error('Error adding platform:', error);
      document.getElementById('message').textContent = 'Error adding platform. Please try again.';
    }
  }
  