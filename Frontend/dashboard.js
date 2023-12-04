document.addEventListener("DOMContentLoaded", function() {
    fetch('https://localhost:7226/Artist')
      .then(response => response.json())
      .then(data => {
        var table = document.getElementById("dashboard");
        table.innerHTML = populateArtists(data)
        console.log(data);    
    })
      .catch(error => console.error('Error:', error))
      .finally(() => {
        addEventHandlers();
      });
});

function populateArtists(data) {
    var result = "";
    data.forEach(element => {
        result += `<tr class='table-row'>
        <td>
          <img id='arrowOpen' data-toggle='collapse' data-target='.row1-details' aria-expanded='false' height='30px' src='img/arrowclosed.png' alt='Closed arrow'>
          <img id='arrowClosed' class='hide' data-toggle='collapse' data-target='.row1-details' width='30px' height='30px' src='img/arrowopen.png' alt='Open arrow'>
        </td>
        <td>` + element.name + `</td>
        <td><a href='artist.html?id=` + element.id + `'><button>Edit</button></a></td>
        <td><button>Delete</button></td>
      </tr>
      <tr id='artistDetails' class='details-row row1-details artistInspection collapse'>
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
