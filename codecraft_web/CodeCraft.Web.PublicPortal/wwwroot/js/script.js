// Counter Animation Script
document.addEventListener("DOMContentLoaded", function () {
  const counters = document.querySelectorAll(".counter");
  const speed = 300; // Adjust speed of counting (larger number = slower)

  // Function to update each counter
  counters.forEach((counter) => {
    const updateCount = () => {
      const target = +counter.getAttribute("data-target");
      let count = 0;
      const increment = target / speed;

      // Function to increment counter
      const countInterval = setInterval(() => {
        count += increment;
        if (count >= target) {
          counter.innerText = target;
          clearInterval(countInterval);
        } else {
          counter.innerText = Math.ceil(count);
        }
      }, 1); // Adjust this for smoother updates
    };

    updateCount();
  });
});

document.addEventListener("DOMContentLoaded", function () {
  const testimonials = document.querySelectorAll(".testimonial");
  let currentIndex = 0;

  function showNextTestimonial() {
    testimonials[currentIndex].classList.remove("active"); // Hide current
    currentIndex = (currentIndex + 1) % testimonials.length; // Move to next
    testimonials[currentIndex].classList.add("active"); // Show next
  }

  // Rotate every 4 seconds
  setInterval(showNextTestimonial, 4000);
});

document.addEventListener("DOMContentLoaded", function () {
  const testimonials = document.querySelectorAll(".testimonial");
  const prevButton = document.getElementById("prev");
  const nextButton = document.getElementById("next");
  let currentIndex = 0;

  function showTestimonial(index) {
    testimonials.forEach((testimonial, i) => {
      testimonial.classList.remove("active");
      testimonial.style.opacity = "0";
      if (i === index) {
        testimonial.classList.add("active");
        testimonial.style.opacity = "1";
      }
    });
  }

  // Show the next testimonial
  nextButton.addEventListener("click", function () {
    currentIndex = (currentIndex + 1) % testimonials.length;
    showTestimonial(currentIndex);
  });

  // Show the previous testimonial
  prevButton.addEventListener("click", function () {
    currentIndex =
      (currentIndex - 1 + testimonials.length) % testimonials.length;
    showTestimonial(currentIndex);
  });

  // Automatically cycle testimonials every 4 seconds
  setInterval(function () {
    currentIndex = (currentIndex + 1) % testimonials.length;
    showTestimonial(currentIndex);
  }, 4000);
});
