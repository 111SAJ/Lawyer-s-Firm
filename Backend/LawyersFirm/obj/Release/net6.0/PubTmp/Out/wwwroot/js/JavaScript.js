function toggleMenu() {
    var navbar = document.querySelector('.navbar');
    var hamburger = document.querySelector('.hamburger');
    navbar.classList.toggle('active');
    hamburger.classList.toggle('active');
}

// Display the modal 2 seconds after page load
document.addEventListener('DOMContentLoaded', function () {
    setTimeout(function () {
        $('#exampleModal').modal('show');
    }, 5000);

    // Initialize AOS
    AOS.init({
        duration: 1200,
    });
});


document.addEventListener('DOMContentLoaded', function () {
    function checkWidthAndUpdateClass() {
        var contentContainers = document.querySelectorAll('.content-container');
        contentContainers.forEach(function (container) {
            if (window.innerWidth <= 575) {
                container.classList.add('text-center');
            } else {
                container.classList.remove('text-center');
            }
        });
    }

    // Initial check
    checkWidthAndUpdateClass();

    // Check on window resize
    window.addEventListener('resize', checkWidthAndUpdateClass);
});


// scroll up starts
// Get the button
let mybutton = document.getElementById("scrollToTopBtn");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
mybutton.addEventListener("click", function () {
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
});
// scroll up ends
