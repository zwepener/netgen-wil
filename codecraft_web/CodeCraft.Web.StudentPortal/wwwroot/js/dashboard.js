// Real-Time Calendar
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

// Call the function on load
window.onload = displayCalendar;
