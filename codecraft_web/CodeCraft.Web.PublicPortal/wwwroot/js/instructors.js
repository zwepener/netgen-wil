document.getElementById('contactForm').addEventListener('submit', function (e) {
    e.preventDefault();
    const name = document.getElementById('studentName').value;
    const email = document.getElementById('studentEmail').value;
    const message = document.getElementById('message').value;

    alert(`Message sent successfully!\nName: ${name}\nEmail: ${email}\nMessage: ${message}`);

    // Clear the form after submission
    document.getElementById('contactForm').reset();

    // Close the modal
    const modal = bootstrap.Modal.getInstance(document.getElementById('contactFormModal'));
    modal.hide();
});