<template>
  <div>
    <NavBar />
    <div>
      <b-jumbotron class header="選擇你要的操作" lead>
        <b-button class="mt-5 mx-2" variant="primary" @click="goCreateAccoune">建立帳號</b-button>
        <b-button class="mt-5 mx-2" variant="primary" @click="goSearchAccount">查看帳號</b-button>
        <!-- <b-button class="mt-5 mx-2" variant="primary" @click="goEditAccount">編輯帳號</b-button> -->
      </b-jumbotron>
    </div>
  </div>
</template>


<script>
import axios from "axios";
import NavBar from "@/components/NavBar";

export default {
  data() {
    return {
      newData: {
        name: "",
        account: "",
        password: "",
        eMail: "",
        charactorId: "",
        lineId: "",
        userId: ""
      },
      CharactorSelect: 1,
      items: [],
      fields: [
        {
          key: "name",
          label: "使用者名稱",
          sortable: true,
          sortDirection: "desc"
        },
        {
          key: "account",
          label: "使用者帳號",
          sortable: true,
          class: "text-center"
        },
        {
          key: "password",
          label: "使用者密碼",
          sortable: true,
          sortDirection: "desc",
          class: "text-center"
        },
        {
          key: "charactorId",
          label: "使用者權限",
          sortable: true,
          sortDirection: "desc",
          class: "text-center",
          formatter: (value /*, key, item*/) => {
            return value
              ? this.CharactorOptions[value].name
              : this.CharactorOptions[0].name;
          }
        },
        {
          key: "eMail",
          label: "信箱",
          sortable: true,
          sortByFormatted: true,
          filterByFormatted: true
        },
        { key: "actions", label: "操作" }
      ],
      CharactorOptions: [
        { charactorId: 0, name: "--請選則--", notEnabled: true },
        { charactorId: 1, name: "系統管理員" },
        { charactorId: 2, name: "教職員工" },
        { charactorId: 3, name: "教師" },
        { charactorId: 4, name: "學生" }
      ],
      totalRows: 1,
      currentPage: 1,
      perPage: 10,
      pageOptions: [10, 15, 20],
      sortBy: "account",
      sortDesc: false,
      sortDirection: "asc",
      filter: null,
      filterOn: [],
      infoModal: {
        id: "info-modal",
        title: "",
        content: ""
      },
      deleteItem: null
    };
  },
  mounted() {},
  computed: {
    sortOptions() {
      // Create an options list from our fields
      return this.fields
        .filter(f => f.sortable)
        .map(f => {
          return { text: f.label, value: f.key };
        });
    }
  },
  components: {
    NavBar,
  },
  methods: {
    goCreateAccoune() {
      this.$router.push({ name: "selectdepartment", params: { operation: 0} });
    },
    goSearchAccount() {
      this.$router.push({ name: "selectdepartment", params: { operation: 1} });
    },
    goEditAccount() {
      this.$router.push({ name: "selectdepartment", params: { operation: 2} });
    },
    info(item, index, button) {
      this.infoModal.title = item.name;
      this.newData.name = item.name;
      this.newData.charactorId = item.charactorId ? item.charactorId : 0;
      this.newData.eMail = item.eMail;
      this.newData.lineId = item.lineId;
      this.newData.account = item.account;
      this.newData.password = item.password;
      this.newData.userId = item.id;
      this.infoModal.content = JSON.stringify(item, null, 2);
      // this.$root.$emit("bv::show::modal", this.infoModal.id, button);
      this.$bvModal.show(this.infoModal.id);
    },
    resetInfoModal() {
      this.infoModal.title = "";
      this.infoModal.content = "";
      this.newData = {
        name: "",
        account: "",
        password: "",
        eMail: "",
        charactorId: "",
        lineId: "",
        userId: ""
      };
    },
    onFiltered(filteredItems) {
      // Trigger pagination to update the number of buttons/pages due to filtering
      this.totalRows = filteredItems.length;
      this.currentPage = 1;
    },
    openAddModal() {
      this.$bvModal.show("addAccountModal");
    },
    createUser() {
      this.fetchData();
      this.$bvModal.hide("addAccountModal");
      this.makeToast("success", "成功建立帳號");
    },
    makeToast(
      variant = null,
      message = "",
      title = "",
      toaster = "b-toaster-top-right"
    ) {
      this.$bvToast.toast(message, {
        title: title,
        toaster: toaster,
        variant: variant,
        solid: true
      });
    }
  }
};
</script>

<style>
</style>