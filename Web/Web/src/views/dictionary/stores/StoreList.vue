<template>
  <div>
    <!-- Content -->
    <div class="content">
      <div class="content-body">
        <div class="content-body-controll">
          <div class="content-body-button" @click="btnAddStore">
            <div class="m-icon-content m-icon-add"></div>
            <div>Thêm mới</div>
          </div>
          <div class="content-body-button" @click="btnCopy">
            <div class="m-icon-content m-icon-copy"></div>
            <div>Nhân bản</div>
          </div>
          <div class="content-body-button" @click="btnEditStore">
            <div class="m-icon-content m-icon-edit"></div>
            <div>Sửa</div>
          </div>
          <div class="content-body-button" @click="btnDelete(false)">
            <div class="m-icon-content m-icon-delete"></div>
            <div>Xóa</div>
          </div>
          <div class="content-body-button" @click="btnRefresh">
            <div
              style="width: 15px; height: 15px"
              class="m-icon-content m-icon-load"
            ></div>
            <div>Nạp</div>
          </div>
        </div>
        <div class="grid grid-store">
          <div class="s-table" id="style-scroll">
            <table>
              <colgroup>
                <col style="width: 15%" />
                <col style="width: 17%" />
                <col style="width: 38%" />
                <col style="width: 15%" />
                <col style="width: 15%" />
              </colgroup>
              <thead>
                <tr class="row">
                  <th id="storecode">
                    Mã cửa hàng <br />
                    <div class="search-group">
                      <div class="input-group">
                        <button>*</button>
                        <input
                          title="Nhập mã cửa hàng muốn tìm"
                          type="text"
                          class="search"
                          v-model="filterCode"
                          @keyup="btnFilter"
                        />
                      </div>
                    </div>
                  </th>
                  <th id="storename">
                    Tên cửa hàng<br />
                    <div class="search-group">
                      <div class="input-group">
                        <button class="item-center">*</button>
                        <input
                          title="Nhập tên cửa hàng muốn tìm"
                          type="text"
                          class="search"
                          v-model="filterName"
                          @keyup="btnFilter"
                        />
                      </div>
                    </div>
                  </th>
                  <th id="storeaddress">
                    Địa chỉ <br />
                    <div class="search-group">
                      <div class="input-group">
                        <button>*</button>
                        <input
                          title="Nhập địa chỉ cửa hàng muốn tìm"
                          type="text"
                          class="search"
                          v-model="filterAddress"
                          @keyup="btnFilter"
                        />
                      </div>
                    </div>
                  </th>
                  <th id="storephone">
                    Số điện thoại<br />
                    <div class="search-group">
                      <div class="input-group">
                        <button>*</button>
                        <input
                          title="Nhập số điện thoại cửa hàng muốn tìm"
                          type="text"
                          class="search"
                          v-model="filterPhone"
                          @keyup="btnFilter"
                        />
                      </div>
                    </div>
                  </th>
                  <th id="storestatus">
                    Trạng thái<br />
                    <select
                      class="search-group"
                      v-model="filterStatus"
                      title="Nhập trạng thái cửa hàng muốn tìm"
                    >
                      <option value="0">Đang hoạt động</option>
                      <option value="1">Đã đóng cửa</option>
                    </select>
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="store in stores"
                  :key="store.storeId"
                  :class="{ trSelected: rowSelected_el === store.storeId }"
                  @click="clickInRow(store)"
                >
                  <td>{{ store.storeCode }}</td>
                  <td>{{ store.storeName }}</td>
                  <td>{{ store.address }}</td>
                  <td>{{ store.phoneNumber }}</td>
                  <td>{{ formatStatus(store.status) }}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <BasePagingBar
          :pagi="pagi"
          @loadData="loadStore"
          :quantityStore="quantityStore"
          :Stores="stores"
        />
      </div>
    </div>
    <StoreListDetail
      :isHideDialog="isHideDialog"
      :store="store"
      :isNameDialog="isNameDialog"
      @changStore="changStore"
      @closeDialog="closeDialog"
      @loadData="reLoad"
      @showSnackbar="showSnackbar"
      @changeSnackBar="changeSnackBar"
      :formMode="formMode"
      ref="dialog"
    />

    <BaseConfirm
      :isHideConfirmDelete="isHideConfirmDelete"
      :store="store"
      :isNameDialog="isNameDialog"
      @btnDelete="btnDelete"
      @deleteStore="deleteStore"
      @changStore="changStore"
    />

    <BaseSnackbar
      :isShowSnackbar="isShowSnackbar"
      :dataSnackBar="dataSnackBar"
    />
    <BaseLoading :showLoading="showLoading" />
  </div>
</template>

<script>
import axios from "axios";
import $ from "jquery";
import "vue-loading-overlay/dist/vue-loading.css";
import BasePagingBar from "../../../components/base/BasePagingBar";
import BaseConfirm from "../../../components/base/BaseConfirm";
import StoreListDetail from "./StoreListDetail";
import BaseSnackbar from "../../../components/base/BaseSnackbar";
import BaseLoading from "../../../components/base/BaseLoading";
export default {
  name: "StoreList",
  components: {
    StoreListDetail,
    BaseConfirm,
    BaseSnackbar,
    BasePagingBar,
    BaseLoading,
  },
  data() {
    return {
      // Đối tượng trả về cho Snackbar
      dataSnackBar: {
        msg: "",
        status: true,
      },
      // Giá trị trong input tìm kiếm
      filterCode: "",
      filterName: "",
      filterAddress: "",
      filterPhone: "",
      filterStatus: 0,
      //Đối tượng chứa dữ liệu trong bảng
      stores: [],
      // Các biến chức năng
      url: "",
      showLoading: true,
      isNameDialog: "",
      isValidated: true,
      isShowSnackbar: true,
      formMode: 1,
      isHideDialog: true,
      isHideConfirmDelete: true,
      rowSelected_el: 0,
      // Các biển sử lý phân trang
      //Tổng số bản ghi trong trang
      quantityPage: 0,
      //Tổng số bản ghi
      quantityStore: 0,
      //Chia thành 10 phần
      pagi: 10,
      // Giá trị bắt đầu
      offset: 0,
      //Đối tượng store
      store: {
        address: "",
        countryId: "",
        createdBy: "",
        createdDate: null,
        districtId: "",
        modifiedBy: "",
        modifiedDate: null,
        phoneNumber: "",
        provinceId: "",
        status: null,
        storeCode: "",
        storeName: "",
        storeTaxCode: "",
        street: "",
        wardId: "",
      },
    };
  },

  async mounted() {
    //Lấy tổng số bản ghi
    // CreatedBy: 
    await axios
      .get("http://localhost:52139/api/v1/Stores/numberData")
      .then((response) => {
        //Gán tổng số bản ghi
        this.quantityStore = response.data;
      });
    // Tổng số bản ghi trong trang
    this.quantityPage = Math.ceil(this.quantityStore / this.pagi);
    this.reLoad();
    this.showLoading = false;
  },
  methods: {
    //Lấy dữ liệu theo trang
    // CreatedBy: hhminh(13/4/2021)
    //Load data
    loadStore: function (number) {
      this.offset = (number - 1) * this.quantityPage;
      this.reLoad();
    },

    //Load lại dữ liệu
    // CreatedBy: hhminh(13/4/2021)
    reLoad: async function () {
      await axios
        .get("http://localhost:52139/api/v1/Stores/paging", {
          params: { positionStart: this.offset, offset: this.quantityPage },
        })
        .then((response) => {
          this.stores = response.data;
        })
        .catch((error) => console.log(error));
    },
    // Sự kiện filter
    // CreatedBy: hhminh(13/4/2021)
    btnFilter() {
      if (this.filterText != "") {
        axios
          .get(
            "http://localhost:52139/api/v1/stores/Filter?StoreCode=" +
              this.filterCode +
              "&StoreName=" +
              this.filterName +
              "&Address=" +
              this.filterAddress +
              "&PhoneNumber=" +
              this.filterPhone +
              "&Status=" +
              this.filterStatus
          )
          .then((res) => {
            this.stores = res.data;
          });
      } else {
        this.loadData();
      }
    },

    //Thay đổi giá trị của đối tượng store
    // CreatedBy: hhminh(13/4/2021)
    changStore(value) {
      if (value == true) {
        this.store = {};
      }
    },

    //Thay đổi data Snackbar
    // CreatedBy: hhminh(13/4/2021)
    changeSnackBar(value) {
      this.dataSnackBar = value;
    },

    //Sự kiện hiện Snackbar
    // CreatedBy: hhminh(13/4/2021)
    showSnackbar(value) {
      this.isShowSnackbar = value;
      // Ẩn Snackbar sau 1.5s khi đã hiện
      setTimeout(() => {
        this.isShowSnackbar = true;
      }, 1500);
    },

    //Sự kiện khi ấn button sửa
    // CreatedBy: hhminh(13/4/2021)
    btnEditStore() {
      if (!this.store.storeId) {
        this.errorInSelection();
      } else {
        //Gán trạng thái là sửa
        this.formMode = 0;
        this.isNameDialog = "Cập nhật cửa hàng";
        // gán lại border cho input
        var inputs = this.$refs.dialog.$refs;
        var array = Object.keys(inputs);
        array.map((item) => {
          inputs[item].style.border = "";
          $(inputs[item]).attr("validate", true);
        });
        //Thay đổi giá trị biến để hiển thị Dialog Sửa
        this.isHideDialog = false;
        //focus vào Input  CustomerCode
        setTimeout(() => {
          this.$refs.dialog.$refs.storeCode.focus();
        }, 0);
      }
    },

    //Sự kiện thay đổi giá trị của biến isHideDialog để thực hiện mở đóng Dialog
    // CreatedBy: hhminh(13/4/2021)
    closeDialog(value) {
      this.store = {};
      this.isHideDialog = value;
    },

    //Sự kiện khi click vào Thêm mới/Sửa
    // CreatedBy: hhminh(13/4/2021)
    btnAddStore() {
      // gán trạng thái là thêm
      this.formMode = 1;
      this.isNameDialog = "Thêm mới cửa hàng";
      // gán lại border cho input và đặt lại validate = false
      var inputs = this.$refs.dialog.$refs;
      var array = Object.keys(inputs);
      array.map((item) => {
        inputs[item].style.border = "";
        $(inputs[item]).attr("validate", false);
      });
      // Gán giá trị false cho biến isHideDialog để hiển thị Dialog thêm
      this.isHideDialog = false;
      //focus vào Input CustomerCode
      setTimeout(() => {
        this.$refs.dialog.$refs.storeCode.focus();
      }, 0);
      // Gán cho đối tượng customer mới để lưu các thông tin nhập vào
      this.store = {};
    },

    // Sự kiện thực hiện xóa
    // CreatedBy: hhminh(13/4/2021)
    deleteStore(str) {
      axios
        .delete("http://localhost:52139/api/v1/stores/" + str.storeId)
        .then(() => {
          this.isHideConfirmDelete = true;
          this.loadData();
          this.dataSnackBar.msg = "Xóa thành công";
          this.dataSnackBar.status = true;
          this.showSnackbar(false);
        })
        .catch(() => {
          this.errorInSelection();
        });
    },

    //Sự kiện thay đổi giá trị của biến isHideConfirmDelete để thực hiện mở đóng Dialog Confirm
    // CreatedBy: hhminh(13/4/2021)
    btnDelete(value) {
      if (!this.store.storeId) {
        this.errorInSelection();
      } else {
        this.isHideConfirmDelete = value;
      }
    },

    //Sự kiện ấn button nạp
    btnRefresh() {
      this.loadData();
    },

    //Sự kiện ấn button nhân bản
    btnCopy() {
      if (!this.store.storeId) {
        this.errorInSelection();
      } else {
        console.log(this.store);
        this.store.storeCode = this.store.storeCode + "CH";
        axios
          .post("http://localhost:52139/api/v1/stores", this.store)
          .then(() => {
            this.loadData();
          });
      }
    },
    //Sự kiện khi click vào một dòng của bảng dữ liệu
    // CreatedBy: hhminh(13/4/2021)
    clickInRow(str) {
      this.rowSelected_el = str.storeId;
      // Gán đối tượng được chọn trong bảng cho đối tượng store
      // this.store = JSON.parse(JSON.stringify(str));
      this.store = { ...str };
      
    },

    //Hàm thông báo lỗi bắt buộc chọn
    //CreatedBy: hhminh(13/4/2021)
    errorInSelection() {
      this.dataSnackBar.msg = "Vui lòng chọn cửa hàng";
      this.dataSnackBar.status = false;
      this.showSnackbar(false);
    },

    //Hàm load dữ liệu
    // CreatedBy: hhminh(13/4/2021)
    async loadData() {
      await axios.get("http://localhost:52139/api/v1/stores").then((res) => {
        this.stores = res.data;
        this.showLoading = false;
      });
    },

    //Hàm định dạng trạng thái hoạt động
    // CreatedBy: hhminh(13/4/2021)
    formatStatus(status) {
      if (status == 0) {
        status = "Đang hoạt động";
      } else {
        status = "Đã đóng cửa";
      }
      return status;
    },
  },

  created() {
    this.loadData();
  },
};
</script>

<style scoped>
.trSelected {
  background-color: #e2e4f1!important;
  color: black;
}
</style>