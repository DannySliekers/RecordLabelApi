document.getElementById("addArtistForm").addEventListener("submit", async function (event) {
    event.preventDefault(); // Prevent the form from reloading the page

    const name = document.getElementById("artistName").value;
    const responseDiv = document.getElementById("response");
    responseDiv.textContent = ""; // Clear previous messages

    // Retrieve JWT token from localStorage
    const token = localStorage.getItem('jwtToken');

    // Prepare headers with the Authorization token if it exists
    const headers = token ? {
        "Authorization": `Bearer ${token}`,
        "Content-Type": "application/json",
    } : {
        "Content-Type": "application/json",
    };

    try {
        const response = await fetch("https://localhost:7226/artist", {
            method: "POST",
            headers: headers, // Include Authorization header if token exists
            body: JSON.stringify({ name })
        });

        if (response.ok) {
            responseDiv.style.color = "green";
            responseDiv.textContent = "Artist added successfully! Redirecting to dashboard...";

            // Redirect to dashboard after a short delay
            setTimeout(() => {
                window.location.href = "dashboard.html";
            }, 2000); // 2-second delay before navigating
        } else {
            const error = await response.json();
            responseDiv.style.color = "red";
            responseDiv.textContent = `Error: ${error.message}`;
        }
    } catch (error) {
        responseDiv.style.color = "red";
        responseDiv.textContent = `Error: ${error.message}`;
    }
});
