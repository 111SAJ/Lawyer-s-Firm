function toggleMenu() {
    var navbar = document.querySelector('.navbar');
    var hamburger = document.querySelector('.hamburger');
    navbar.classList.toggle('active');
    hamburger.classList.toggle('active');
}

// Display the modal 2 seconds after page load
document.addEventListener('DOMContentLoaded', function() {
    setTimeout(function() {
        $('#exampleModal').modal('show');
    }, 2000);

    // Initialize AOS
    AOS.init({
        duration: 1200,
    });
});