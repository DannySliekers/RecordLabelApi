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