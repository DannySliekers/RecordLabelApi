document.getElementById('registerForm').addEventListener('submit', async function (event) {
    event.preventDefault(); // Prevent form from submitting normally

    const username = document.getElementById('username').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    const messageElement = document.getElementById('message');

    try {
        const response = await fetch('https://localhost:7226/auth/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, email, password }),
        });

        const result = await response.json();

        if (response.ok) {
            messageElement.textContent = result.message || 'Registration successful!';
            messageElement.classList.add('success');
            messageElement.classList.remove('error');

            // Redirect to login page after successful registration
            setTimeout(function () {
                window.location.href = 'login.html';  // Redirect to login.html
            }, 2000); // Delay the redirect by 2 seconds to allow the success message to be visible
        } else {
            messageElement.textContent = result.message || 'An error occurred.';
            messageElement.classList.add('error');
            messageElement.classList.remove('success');
        }
    } catch (error) {
        messageElement.textContent = 'Failed to connect to the server.';
        messageElement.classList.add('error');
        messageElement.classList.remove('success');
    }
});
