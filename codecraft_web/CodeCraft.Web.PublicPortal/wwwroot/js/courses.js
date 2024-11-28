document.getElementById("searchBar").addEventListener("input", function () {
  const searchQuery = this.value.toLowerCase();
  const courses = document.querySelectorAll("#courseListings .card");

  courses.forEach((course) => {
    const title = course.querySelector(".card-title").innerText.toLowerCase();
    const description = course
      .querySelector(".card-text")
      .innerText.toLowerCase();

    if (title.includes(searchQuery) || description.includes(searchQuery)) {
      course.parentElement.style.display = "block"; // Show matching course
    } else {
      course.parentElement.style.display = "none"; // Hide non-matching course
    }
  });
});

// Clear filters
document.getElementById("clearFiltersBtn").addEventListener("click", (e) => {
  e.preventDefault();
  document
    .querySelectorAll("#filterForm input:checked")
    .forEach((checkbox) => (checkbox.checked = false));
  renderCourses(allCourses);
});
