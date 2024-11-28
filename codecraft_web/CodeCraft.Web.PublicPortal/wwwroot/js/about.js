document.querySelectorAll(".step").forEach((step, index, steps) => {
  const progressLine = document.getElementById("line-progress"); // The progress line
  const progressContents = document.querySelectorAll(".section-content"); // All content sections
  const progressBarWidth = ((index + 1) / steps.length) * 100; // Calculate width as percentage

  step.addEventListener("click", () => {
    // Remove 'active' and 'completed' classes from all steps
    steps.forEach((s) => {
      s.classList.remove("active");
      s.classList.remove("completed");
    });

    // Mark the clicked step as 'active' and the previous ones as 'completed'
    for (let i = 0; i <= index; i++) {
      steps[i].classList.add("completed");
    }
    step.classList.add("active");

    // Update the width of the progress line dynamically
    progressLine.style.width = `${progressBarWidth}%`;

    // Hide all content sections and only show the corresponding one
    progressContents.forEach((content) => {
      content.classList.remove("active");
    });

    // Add 'active' class to the clicked step's content
    progressContents[index].classList.add("active");
  });
});
