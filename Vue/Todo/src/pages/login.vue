<script setup>
import { ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
const router = useRouter();
const API_URL = "https://localhost:7068";




const login = ref({
  userName: "bobo1",
  pwd: "123",
});

const register = ref({
  username: "bobo3",
  Pwd: "123456",
  email: "bobo3@gmail.com",
});

//錯誤寫法
// const hadlesubmit = async () => {
//   await axios
//     .post("https://localhost:7068/api/User/register", {
//       register,
//     })
//     //請求成功的回覆
//     .then((response) => {
//       console.log(response.data);
//     })
//     //失敗的回覆
//     .catch((error) => {
//       console.log(error);
//     });
// };
// const hadlesubmit = async (event) => {
//   event.preventDefault();

//   try {
//     const response = await axios.post(
//       "https://localhost:7068/api/User/register",
//       register.value
//     );
//     console.log(response.data);
//   } catch (error) {
//     console.log(error);
//   }
// };

// const CheckAccount = (event) => {
//   event.preventDefault();
//   axios
//     .post("https://localhost:7068/api/User/login", login.value)
//     .then((response) => {
//       console.log(response.data);
//       router.push("/");
//     })
//     .catch((error) => {
//       console.log(error);
//     });
// };

const token = ref(null); //儲存Token用

const CheckAccount = async (event) => {
  event.preventDefault();
  try {
    const response = await axios.post(`${API_URL}/api/User/login`, login.value);
    localStorage.setItem("jwtToken",response.data.token);
    router.push('/');
  } catch (error) {
    console.log(error);
  }
};





const hadlesubmit = (event) => {
  event.preventDefault();

  axios
    .post(`${API_URL}/api/User/register`, register.value)
    .then((response) => {
      console.log(response.data);
    })
    .catch((error) => {
      console.log(error);
    });
};

const showModal = ref(false);
const view = ref(1);
const changeView = (index) => {
  view.value = index;
};

</script>
<template>
  
  <div class="ALL">
    <div class="overlay" v-if="view === 3">
      <div class="modal">
        <textarea name="note" id="note" cols="30" rows="10"></textarea>
        <button @click="SubmitToken">送出</button>
        <button class="close" @click="changeView(1)">Close</button>
      </div>
    </div>
    <header>
      <h2 class="logo">Todolist</h2>
      <nav class="navigation">
        <!-- <a href="#" @click="changeView(3)">驗證</a> -->
        <!-- <a href="#">TEST</a>
            <a href="#">TEST</a>
            <a href="#">TEST</a>
            <a href="#">TEST</a> -->
        <button @click="changeView(1)" class="btnLogin-popup">Login</button>
      </nav>
    </header>
    <div class="wrapper">
      <span class="icon-close">
        <font-awesome-icon icon="fa-solid fa-xmark" />
      </span>
      <div class="form-box login" v-if="view === 1">
        <h2>Login</h2>
        <form action="#">
          <div class="input-box">
            <span class="icon"><font-awesome-icon icon="fa-solid fa-user" /></span>
            <input type="text" v-model="login.userName" required />
            <label for=""> UserName</label>
          </div>
          <div class="input-box">
            <span class="icon"><font-awesome-icon icon="fa-solid fa-lock" /></span>
            <input type="password" v-model="login.pwd" required />
            <label for=""> Password</label>
          </div>
          <div class="remember-forget">
            <label><input type="checkbox" />記住我</label>
            <a href="#">忘記密碼?</a>
          </div>
          <button type="submit" class="btn" @click="CheckAccount">Login</button>
          <div class="login-register">
            <p>
              還沒有帳號?<a
                @click="changeView(2)"
                href="#"
                class="register-link"
                >註冊</a
              >
            </p>
          </div>
        </form>
      </div>

      <div class="form-box register" v-if="view === 2">
        <h2>Registerion</h2>
        <form action="#">
          <div class="input-box">
            <span class="icon"><font-awesome-icon icon="fa-solid fa-envelope" /></span>
            <input type="text" v-model="register.email" required />
            <label for=""> Email</label>
          </div>
          <div class="input-box">
            <span class="icon"><font-awesome-icon icon="fa-solid fa-user" /></span>
            <input type="text" v-model="register.username" required />
            <label for=""> UserName</label>
          </div>
          <div class="input-box">
            <span class="icon"><font-awesome-icon icon="fa-solid fa-lock" /></span>
            <input type="password" v-model="register.Pwd" required />
            <label for=""> Password</label>
          </div>
          <div class="remember-forget">
            <label><input type="checkbox" />我同意此項條款</label>
          </div>
          <button @click="hadlesubmit" type="submit" class="btn">
            Register
          </button>
          <div class="login-register">
            <p>
              已經有帳號了?<a @click="changeView(1)" href="#" class="login-link"
                >登入</a
              >
            </p>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>


<style scoped>
.ALL {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background: url("src/background3.jpg") no-repeat;
  background-size: cover;
  background-position: center;
  width: 100%;
  box-shadow: inset 0 0 100px rgba(0, 0, 0, 0.5);
}

header {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  padding: 20px 100px;
  background-color: rgb(39, 37, 36);
  display: flex;
  justify-content: space-between;
  align-items: center;
  z-index: 99;
}

.logo {
  font-size: 2em;
  color: #fff;
}

.navigation a {
  position: relative;
  font-size: 1.1em;
  color: #fff;
  text-decoration: none;
  font-weight: 500;
  margin-left: 40px;
}

.navigation a::after {
  content: "";
  position: absolute;
  left: 0;
  bottom: -6px;
  width: 100%;
  height: 3px;
  background: #fff;
  border-radius: 5px;
  transform-origin: right;
  transform: scaleX(0);
  transition: transform 0.5s;
}

.navigation a:hover::after {
  transform: scaleX(1);
}

.navigation .btnLogin-popup {
  width: 130px;
  height: 50px;
  background: transparent;
  border: 2px solid #fff;
  outline: none;
  border-radius: 6px;
  cursor: pointer;
  font-size: 1.1em;
  color: #fff;
  font-weight: 500;
  margin-left: 40px;
  transition: 0.5s;
}

.navigation .btnLogin-popup:hover {
  background: #fff;
  color: #162938;
}

.wrapper {
  position: relative;
  width: 600px;
  height: 650px;
  background: transparent;
  border: 2px solid rgba(255, 255, 255, 0.5);
  border-radius: 20px;
  backdrop-filter: blur(20px);
  box-shadow: 0 0 30px rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  overflow: hidden;
}

.wrapper .form-box {
  width: 100%;
  padding: 40px;
}

.form-box .gender-details .gender-title {
  color: black;
  font-size: 25px;
  font-weight: 400;
}

.form-box .category {
  color: black;
  display: flex;
  width: 80%;
  margin: 14px 0;
  justify-content: space-between;
}

.form-box .category label {
  display: flex;
  align-items: center;
  cursor: pointer;
}

.form-box .category label .dot {
  height: 18px;
  width: 18px;
  border-radius: 50%;
  margin-right: 10px;
  background: #d9d9d9;
  border: 5px solid transparent;
  transition: all 0.3s ease;
}

#dot-1:checked ~ .category label .one,
#dot-2:checked ~ .category label .two,
#dot-3:checked ~ .category label .three {
  background: #9b59b6;
  border-color: #d9d9d9;
}

.form-box input[type="radio"] {
  display: none;
}
/* .wrapper .form-box.register {
  /* position: absolute;
  transform: translateX(400px); }*/

.wrapper .icon-close {
  position: absolute;
  top: 0;
  right: 0;
  width: 45px;
  height: 45px;
  background: #162938;
  font-size: 2em;
  color: #fff;
  display: flex;
  justify-content: center;
  align-items: center;
  border-bottom-left-radius: 20px;
  cursor: pointer;
  z-index: 1;
}

.form-box h2 {
  font-size: 2em;
  color: #162938;
  text-align: center;
}

.input-box {
  position: relative;
  width: 100%;
  height: 50px;
  border-bottom: 2px solid #162938;
  margin: 30px 0;
}

.input-box label {
  position: absolute;
  top: 50%;
  left: 5px;
  transform: translateY(-50%);
  font-size: 1em;
  color: #162938;
  font-weight: 500;
  pointer-events: none;
  transition: 0.5s;
}

.input-box input:focus ~ label,
.input-box input:valid ~ label {
  top: -5px;
}

.input-box input {
  width: 100%;
  height: 100%;
  background: transparent;
  border: none;
  outline: none;
  font-size: 1em;
  color: #162938;
  font-weight: 600;
  padding: 0 25px 0 5px;
}

.input-box .icon {
  position: absolute;
  right: 8px;
  font-size: 1.2em;
  color: #162938;
  line-height: 57px;
}

.remember-forget {
  font-size: 0.9em;
  color: #162938;
  font-weight: 500;
  margin: -15px 0 15px;
  display: flex;
  justify-content: space-between;
}

.remember-forget label input {
  accent-color: #162938;
  margin-right: 3px;
}

.remember-forget a {
  color: #162938;
  text-decoration: none;
}

.remember-forget a:hover {
  text-decoration: underline;
}

.btn {
  width: 100%;
  height: 45px;
  background: #162938;
  border: none;
  outline: none;
  border-radius: 6px;
  cursor: pointer;
  font-size: 1em;
  color: #fff;
  font-weight: 500;
}

.login-register {
  font-size: 0.9em;
  color: #162938;
  text-align: center;
  font-weight: 500;
  margin: 25px 0 10px;
}

.login-register p a {
  color: #162938;
  text-decoration: none;
  font-weight: 600;
}

.login-register p a:hover {
  text-decoration: underline;
}

/* 彈窗 */
.overlay {
  position: absolute;
  width: 100%;
  height: 30%;
  /* background-color: rgba(0, 0, 0, 0.77); */
  z-index: 10;
  display: flex;
  align-items: center;
  justify-content: center;
}

.modal {
  width: 500px;
  background-color: white;
  border-radius: 10px;
  padding: 30px;
  position: relative;
  display: flex;
  flex-direction: column;
}
.modal button {
  padding: 10px 20px;
  font-size: 20px;
  width: 100%;
  background-color: rgb(37, 138, 204);
  border: none;
  color: white;
  cursor: pointer;
  margin-top: 15px;
}
.modal .close {
  background-color: rgb(181, 45, 45);
  margin-top: 7px;
}
</style>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: "Poppins" sans-serif;
}
</style>