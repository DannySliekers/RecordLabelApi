const urlParams = new URLSearchParams(window.location.search);
const artistId = urlParams.get('artistId');

// Fetch platform options when the page loads
document.addEventListener('DOMContentLoaded', function() {
    // Fetch platform data from the API
    fetchPlatforms();

    // Handle form submission
    const form = document.getElementById('addSingleForm');
    form.addEventListener('submit', function(event) {
        event.preventDefault();

        const formData = {
            title: document.getElementById('title').value,
            status: document.getElementById('status').value,
            playlength: document.getElementById('playlength').value,
            cover: document.getElementById('cover').value,
            platformid: parseInt(document.getElementById('platform').value),
            artistid: artistId // Replace with actual artist ID dynamically
        };

        // Make API call to add single
        addSingle(formData);
    });
});

// Fetch platform data from the API
function fetchPlatforms() {
    const token = localStorage.getItem('jwtToken');
    const headers = token ? {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
    } : {
        'Content-Type': 'application/json'
    };

    fetch('https://localhost:7226/Platform', {
        method: 'GET',
        headers: headers
    })
    .then(response => response.json())
    .then(platforms => {
        const platformSelect = document.getElementById('platform');
        
        // Clear existing options (if any)
        platformSelect.innerHTML = '';

        // Add a default "Select Platform" option
        const defaultOption = document.createElement('option');
        defaultOption.value = '';
        defaultOption.textContent = 'Select Platform';
        platformSelect.appendChild(defaultOption);

        // Add the platform options fetched from the API
        platforms.forEach(platform => {
            const option = document.createElement('option');
            option.value = platform.id;
            option.textContent = platform.name;
            platformSelect.appendChild(option);
        });
    })
    .catch(error => {
        console.error('Error fetching platforms:', error);
    });
}

function addSingle(data) {
    const token = localStorage.getItem('jwtToken');
    const headers = token ? {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
    } : {
        'Content-Type': 'application/json'
    };

    fetch('https://localhost:7226/single', {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(data)
    })
    .then(response => response.json())
    .then(result => {
        document.getElementById('message').textContent = 'Single added successfully!';

        setTimeout(() => {
            window.location.href = 'dashboard.html'; // Redirect to dashboard
        }, 2000);
    })
    .catch(error => {
        console.error('Error adding single:', error);
        document.getElementById('message').textContent = 'Error adding single. Please try again.';
    });
}
