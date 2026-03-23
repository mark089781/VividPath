import * as utils from "./utils.js";

// SESSION
let isLoggedIn = false; // CHANGE

const PageScript = {
    main: function() {
        utils.debug("This is Main");

        // LOCAL VARIABLE
        const learn = document.getElementById("card2");
        const learn1 = document.getElementById("card3");

        learn.addEventListener("click", function (){
            window.location.href = "/Home/Learn";
        });


        learn1.addEventListener("click", function (){
            window.location.href = "/Home/Learn";   
            console.log("record");
        });

        utils.debug("Is Logged in:" + isLoggedIn);
    },

    login: function() {
        utils.debug("This is Log In");

        // LOCAL VARIABLES
        const logInForm = document.getElementById("logInForm");
        const email = document.getElementById("email");
        const password = document.getElementById("password");

        
        logInForm.addEventListener("submit", async function (e) {
            e.preventDefault();
            
            utils.debug("This is submitted");

            await fetch("/Home/LogIn", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    Email: email.value,
                    Password: password.value
                })
            }).then(res => res.json())
            .then(data => {
                utils.debug("logIn");

                window.location.href = data.redirect;
                isLoggedIn = data.isLoggedIn; // CHANGE 
                utils.debug(data.isLoggedIn);
            })
            .then(err => { utils.debug(err); });

        });
    },

    register: function() {
        utils.debug("This is the Register Page");
    },

    profile: function() {
        const logOutBtn = document.getElementById("logOutBtn");

        logOutBtn.addEventListener("click", function() {
            utils.logOut();
        });

    }
};

document.addEventListener("DOMContentLoaded", function () {
    const page = document.body.dataset.page;

    if (PageScript[page]) {
        PageScript[page] ();
    }
});



