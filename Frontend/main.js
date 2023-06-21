// Function for getting the projects data from the GET method /GetProjects
$(document).ready(function () {
  $.ajax({
    url: "https://localhost:7031/Project/GetProjects",
  }).then(function (data) {
    for (i = 0; i < data.length; i++) {
      $("#title" + [i]).append(data[i].title);
      $("#description" + [i]).append(data[i].description);
      $("#link" + [i]).attr("href", data[i].link);
    }
  });
});

// Cursor
const cursorDot = document.querySelector("[data-cursor-dot]");
const cursorOutline = document.querySelector("[data-cursor-outline]");

window.addEventListener("mousemove", function (e) {
  const posX = e.clientX;
  const posY = e.clientY;

  cursorDot.style.left = `${posX}px`;
  cursorDot.style.top = `${posY}px`;

  cursorOutline.style.left = `${posX}px`;
  cursorOutline.style.top = `${posY}px`;
});

// Typing animation for my "hobbies"
var typed = new Typed(".auto-type", {
  strings: ["programming", "football", "gaming"],
  typeSpeed: 100,
  backSpeed: 100,
  loop: true,
});

// POST contact form to C# that then uses MailKit, so I can receive the data as an e-mail
$(document).ready(function () {
  $("form").submit(function (event) {
    var formData = {
      mail: $("#mail").val(),
      subject: $("#subject").val(),
      message: $("#message").val(),
    };

    $.ajax({
      type: "POST",
      url: "https://localhost:7031/Email/PostContact",
      data: JSON.stringify(formData),
      contentType: "application/json; charset=utf-8",
    })
      .done(function (data) {
        console.log(data);
      })
      .fail(function (data) {
        console.log(data);
      });

    event.preventDefault();
  });
});

// Selecting hamburger SVG so I can use it's click event
const hamburger = document.querySelector("#hamburger");
// Selecting the projects text/option so I can use it's click event
const projectsOption = document.querySelector("#projects-option");
// Selecting the contact text/option so I can use it's click event
const contactOption = document.querySelector("#contact-option");
// Selecting menu ID so I can use it's classList to toggle the hidden attribute
const menu = document.querySelector("#menu");

// Adding a function that uses the addEvenListener("click")
// which then toggles the hidden attribute
hamburger.addEventListener("click", () => {
  menu.classList.toggle("hidden");
});
// Same as above but for projects
projectsOption.addEventListener("click", () => {
  menu.classList.toggle("hidden");
});
// Same as above but for contact
contactOption.addEventListener("click", () => {
  menu.classList.toggle("hidden");
});
