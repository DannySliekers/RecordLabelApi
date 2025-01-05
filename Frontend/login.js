document.getElementById('loginForm').addEventListener('submit', async function(event) {
    event.preventDefault(); // Prevent form from submitting normally

    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const messageElement = document.getElementById('message');
    
    // Clear any previous messages
    messageElement.textContent = '';
    messageElement.classList.remove('alert', 'alert-success', 'alert-danger');
    
    try {
      const response = await fetch('https://localhost:7226/auth/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ username, password })
      });

      const result = await response.json();
      
      if (response.ok) {
        // If login is successful
        messageElement.textContent = result.message || 'Login successful!';
        messageElement.classList.add('alert', 'alert-success');
        // Redirect to a protected page or dashboard (replace with your desired location)
        setTimeout(function() {
          window.location.href = 'dashboard.html'; // Redirect after successful login
        }, 2000); // Wait 2 seconds before redirecting
      } else {
        // If login fails
        messageElement.textContent = result.message || 'Invalid username or password';
        messageElement.classList.add('alert', 'alert-danger');
      }
    } catch (error) {
      console.error('Login error:', error);
      messageElement.textContent = 'Error connecting to the server. Please try again later.';
      messageElement.classList.add('alert', 'alert-danger');
    }
  });