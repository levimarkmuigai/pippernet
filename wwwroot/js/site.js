// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.addEventListener("DOMContentLoaded", function () {
    let loader = document.createElement("div");
    loader.id = "page-loader";
    loader.innerHTML = '<div class="spinner"></div>';
    document.body.appendChild(loader);

    setTimeout(() => {
        loader.style.opacity = "0";
        setTimeout(() => loader.remove(), 500);
    }, 1000); // Simulates a 1s loading delay
});


window.addEventListener("scroll", function () {
    let navbar = document.querySelector(".navbar");
    if (window.scrollY > 50) {
        navbar.classList.add("sticky");
    } else {
        navbar.classList.remove("sticky");
    }
});


document.addEventListener("DOMContentLoaded", function () {
    let toggleBtn = document.createElement("button");
    toggleBtn.innerText = "🌙";
    toggleBtn.id = "dark-mode-toggle";
    
    // Apply styling directly
    toggleBtn.style.position = "fixed";
    toggleBtn.style.top = "10px";
    toggleBtn.style.right = "10px";
    toggleBtn.style.padding = "10px";
    toggleBtn.style.border = "none";
    toggleBtn.style.background = "#444";
    toggleBtn.style.color = "#fff";
    toggleBtn.style.cursor = "pointer";
    toggleBtn.style.borderRadius = "5px";
    toggleBtn.style.zIndex = "1000";

    document.body.appendChild(toggleBtn);

    // Load user preference
    if (localStorage.getItem("darkMode") === "enabled") {
        document.body.classList.add("dark-mode");
        toggleBtn.innerText = "☀️";
    }

    toggleBtn.addEventListener("click", function () {
        document.body.classList.toggle("dark-mode");
        let isDarkMode = document.body.classList.contains("dark-mode");
        toggleBtn.innerText = isDarkMode ? "☀️" : "🌙";

        // Save user preference
        localStorage.setItem("darkMode", isDarkMode ? "enabled" : "disabled");
    });
});


