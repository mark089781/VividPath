export function debug(message) {
    console.log("Error: ", message);
}

export async function logOut() {
    await fetch("/Home/LogOut", {
        method: "POST"
    });

    window.location.replace("/Home/Main")
} 