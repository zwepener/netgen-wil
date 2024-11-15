// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Real-Time Calendar Function for All Pages
function displayCalendar() {
    const calendarEl = document.getElementById("calendar");
    const date = new Date();
    const month = date.toLocaleString("default", { month: "long" });
    const year = date.getFullYear();

    calendarEl.innerHTML = `
        <h3>${month} ${year}</h3>
        <p>${date.toDateString()}</p>
    `;
}

window.onload = displayCalendar;
