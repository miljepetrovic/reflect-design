document.addEventListener("DOMContentLoaded", function () {
    const menuToggle = document.getElementById("mobile-menu-toggle");
    const menu = document.getElementById("mobile-menu");
    const menuIcon = document.getElementById("menu-icon");
    const closeIcon = document.getElementById("close-icon");

    menuToggle.addEventListener("click", function () {
        menu.classList.toggle("hidden");
        menuIcon.classList.toggle("hidden");
        closeIcon.classList.toggle("hidden");
    });

    document.querySelectorAll(".dropdown-toggle").forEach(button => {
        button.addEventListener("click", function (event) {
            event.stopPropagation();
            const dropdownMenu = this.nextElementSibling;
            dropdownMenu.classList.toggle("hidden");
        });
    });
});