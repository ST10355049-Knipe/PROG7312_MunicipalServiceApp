// This script handles the event detail modal popup.
document.addEventListener('DOMContentLoaded', function () {
    var eventDetailModal = document.getElementById('eventDetailModal');
    if (eventDetailModal) {
        // This event listener waits for the modal to be opened.
        eventDetailModal.addEventListener('show.bs.modal', function (event) {

            // Get the event card that was clicked to open the modal.
            var card = event.relatedTarget;
            var eventId = card.getAttribute('data-eventid');

            // Build the URL to call my GetEventById action in the HomeController.
            var url = '/Home/GetEventById?id=' + eventId;

            // Use the Fetch API to make an asynchronous call to my controller.
            fetch(url)
                .then(response => response.json()) // Convert the response to JSON.
                .then(data => {
                    // Once I have the data, I find the elements in the modal...
                    var modalTitle = eventDetailModal.querySelector('.modal-title');
                    var modalImage = eventDetailModal.querySelector('#eventModalImage');
                    var modalDescription = eventDetailModal.querySelector('#eventModalDescription');
                    var modalDate = eventDetailModal.querySelector('#eventModalDate');
                    var modalLocation = eventDetailModal.querySelector('#eventModalLocation');
                    var modalCategory = eventDetailModal.querySelector('#eventModalCategory');

                    // ...and update their content with the event's details.
                    modalTitle.textContent = data.title;
                    modalImage.src = data.imageUrl;
                    modalDescription.textContent = data.description;
                    modalDate.textContent = new Date(data.date).toLocaleDateString('en-GB', { day: 'numeric', month: 'long', year: 'numeric' });
                    modalLocation.textContent = data.location;
                    modalCategory.textContent = data.category;
                })
                .catch(error => console.error('Error fetching event data:', error));
        });
    }
});