    var selectedSubjects = {
        pk_StudentId: [document.getElementById('Pk_StudentId').value],
    common: [],
    additional: [],
    elective: []
        };
    // JavaScript code to handle checkbox clicks
    document.addEventListener('DOMContentLoaded', function () {


            // Add event listeners to each checkbox
            var checkboxes = document.querySelectorAll('input[type=checkbox]');
    checkboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', function () {
            var subjectType = this.name; // Get the type of subject (common, additional, or elective)
            var subjectCode = this.value; // Get the subject code

            // If the checkbox is checked
            if (this.checked) {
                // Check if the subject code is already selected in any of the arrays
                for (var type in selectedSubjects) {
                    if (type !== 'additional' && selectedSubjects[type].includes(subjectCode)) {
                        alert('Subject ' + subjectCode + ' is already selected in ' + type + ' subjects.');
                        this.checked = false; // Uncheck the checkbox
                        return; // Exit the function to prevent adding the subject code again
                    }
                    else if (type !== 'elective' && selectedSubjects[type].includes(subjectCode)) {
                        alert('Subject ' + subjectCode + ' is already selected in ' + type + ' subjects.');
                        this.checked = false; // Uncheck the checkbox
                        return;
                    }
                }

                // Check if the subject is common and already has two subjects
                if (subjectType === 'common' && selectedSubjects.common.length >= 2) {
                    alert('Common subjects can only have two subject codes.');
                    this.checked = false; // Uncheck the checkbox
                    return; // Exit the function to prevent adding the subject code again
                }

                // Check if the subject is additional and already exists
                if (subjectType === 'additional' && selectedSubjects.additional.length > 0) {
                    alert('Additional subjects can only have one subject code.');
                    this.checked = false; // Uncheck the checkbox
                    return; // Exit the function to prevent adding the subject code again
                }

                // Check if the subject is elective and already has three subjects
                if (subjectType === 'elective' && selectedSubjects.elective.length >= 3) {
                    alert('Elective subjects can only have three subject codes.');
                    this.checked = false; // Uncheck the checkbox
                    return; // Exit the function to prevent adding the subject code again
                }

                // Add the subject code to the appropriate array
                selectedSubjects[subjectType].push(subjectCode);
            } else {
                // If the checkbox is unchecked
                // Remove the subject code from the appropriate array
                var index = selectedSubjects[subjectType].indexOf(subjectCode);
                if (index !== -1) {
                    selectedSubjects[subjectType].splice(index, 1);
                    // alert('Subject ' + subjectCode + ' removed from ' + subjectType + ' subjects.');
                }
            }

            console.log(selectedSubjects); // Output the array to console (for testing)
        });
            });
        });

    document.addEventListener('DOMContentLoaded', function () {
            debugger;
    // Get reference to the submit button
    const submitButton = document.getElementById('submitButton');

    // Add click event listener to the submit button
    submitButton.addEventListener('click', function (event) {
        // Prevent the default form submission behavior
        event.preventDefault();

    // Call the function to send data to the controller
    sendDataToController(selectedSubjects);
            });
        });

    function sendDataToController(selectedSubjects) {
            debugger;
    const urll = '@Url.Action("AddStudentSubjects", "Values")';
    // Assuming your controller endpoint is '/your-controller-endpoint'
    const url = urll;

    // Assuming your controller accepts POST requests and expects JSON data
    const options = {
        method: 'POST',
    headers: {
        'Content-Type': 'application/json'
                },
    body: JSON.stringify(selectedSubjects) // Assuming selectedSubjects is the data you want to send
            };

    // Sending the data to the controller
    fetch(url, options)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
    return response.json();
                })
                .then(result => {
        // Handle the response from the controller if needed
        console.log('Controller response:', result);

    // Redirect to another action method with the ID
    window.location.href = '/User/Preview?id=' + result.Id; // Adjust the URL as per your application's routing
                })
                .catch(error => {
        // Handle errors that may occur during the request
        console.error('Error sending data to controller:', error);
                });

        }


