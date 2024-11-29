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
