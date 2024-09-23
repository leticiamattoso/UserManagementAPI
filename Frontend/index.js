async function listUsers() {
    try {
        const response = await fetch("http://localhost:5224/api/User/GetAll");
        const users = await response.json();
        populateTable(users);
        console.log(users);
    } catch (error) {
        console.error("Erro:", error);
    }
}

function populateTable(users) {
    const tableBody = document.getElementById("usersTable").querySelector("tbody");

    tableBody.innerHTML = '';

    users.forEach(user => {
        const row = document.createElement("tr");

        const imageCell = document.createElement("td");
        const img = document.createElement("img");
        img.src = user.pictureLarge;
        img.alt = "Imagem do usuário";
        img.style.width = "40px";
        img.style.height = "40px";
        imageCell.appendChild(img);
        row.appendChild(imageCell);

        const idCell = document.createElement("td");
        idCell.textContent = user.id;
        row.appendChild(idCell);

        const nameCell = document.createElement("td");
        const nameInput = document.createElement("input");
        nameInput.type = "text";
        nameInput.value = user.firstName;
        nameCell.appendChild(nameInput);
        row.appendChild(nameCell);

        const genderCell = document.createElement("td");
        const genderInput = document.createElement("input");
        genderInput.type = "text";
        genderInput.value = user.gender;
        genderCell.appendChild(genderInput);
        row.appendChild(genderCell);

        const ageCell = document.createElement("td");
        const ageInput = document.createElement("input");
        ageInput.type = "text";
        ageInput.value = user.age;
        ageCell.appendChild(ageInput);
        row.appendChild(ageCell);

        const phoneCell = document.createElement("td");
        const phoneInput = document.createElement("input");
        phoneInput.type = "text";
        phoneInput.value = user.phone;
        phoneCell.appendChild(phoneInput);
        row.appendChild(phoneCell);

        const userCell = document.createElement("td");
        const userInput = document.createElement("input");
        userInput.type = "text";
        userInput.value = user.userName;
        userCell.appendChild(userInput);
        row.appendChild(userCell);

        const emailCell = document.createElement("td");
        const emailInput = document.createElement("input");
        emailInput.type = "email";
        emailInput.value = user.email;
        emailCell.appendChild(emailInput);
        row.appendChild(emailCell);


        const actionsCell = document.createElement("td");
        const saveButton = document.createElement("button");
        saveButton.textContent = "Atualizar";
        saveButton.onclick = () => {
            const updatedUser = {
                id: user.id,
                firstName: nameInput.value,
                gender: genderInput.value,
                age: ageInput.value,
                phone: phoneInput.value,
                userName: userInput.value,
                email: emailInput.value,
            };
            updateUser(updatedUser);
        };
        actionsCell.appendChild(saveButton);
        row.appendChild(actionsCell);

        tableBody.appendChild(row);
    });
}

async function addUser() {
    try {
        const response = await fetch("http://localhost:5224/api/User/Create", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
        });

        if (response.ok) {
            alert("Usuário adicionado com sucesso!");
            listUsers();
        } else {
            alert("Erro ao adicionar usuário.");
        }
    } catch (error) {
        console.error("Erro:", error);
    }
}

async function updateUser(updatedUser) {
    try {
        const response = await fetch("http://localhost:5224/api/User/Update", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedUser)
        });

        if (response.ok) {
            alert("Usuário atualizado com sucesso!");
            listUsers();
        } else {
            alert("Erro ao atualizar usuário.");
        }
    } catch (error) {
        console.error("Erro:", error);
    }
}

document.getElementById("addUserButton").onclick = addUser;
listUsers();