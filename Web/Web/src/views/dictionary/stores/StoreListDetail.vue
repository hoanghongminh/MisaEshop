<template>
  <!--dialog-->
  <div class="m-dialog" :class="{ isHideDialog: isHideDialog }">
    <div class="dialog-modal"></div>
    <div class="dialog dialog-content">
      <div class="form-header">
        <strong class="title item-center">{{ this.isNameDialog }}</strong>
        <div class="btn-x item-center" @click="btnClose">
          <i class="icon-x" title="Đóng"></i>
        </div>
        <div class="clear"></div>
      </div>
      <div class="form-body">
        <div class="content-center">
          <div class="input-requied">
            <div class="input-title">
              Mã cửa hàng
              <span class="label-requied">*</span>
            </div>
            <input
              tabindex="1"
              id="storeCode"
              @blur="isValidate('storeCode')"
              type="text"
              name=""
              placeholder=""
              validate="false"
              ref="storeCode"
              required
              v-model="store.storeCode"
              class="border-input-requied"
            />
            <div>
              <div class="talk-bubble" id="storeCode_wrang">
                <div class="talktext">
                  <p>Dữ liệu không hợp lệ</p>
                </div>
              </div>
            </div>
          </div>
          <div class="input-requied">
            <div class="input-title">
              Tên cửa hàng
              <span class="label-requied">*</span>
            </div>
            <input
              tabindex="2"
              id="storeName"
              validate="false"
              @blur="isValidate('storeName')"
              type="text"
              class="form-control border-input-requied"
              name=""
              placeholder=""
              ref="storeName"
              required
              v-model="store.storeName"
            />
            <div>
              <div class="talk-bubble" id="storeName_wrang">
                <div class="talktext">
                  <p>Dữ liệu không hợp lệ</p>
                </div>
              </div>
            </div>
          </div>
          <div class="input-requied">
            <div class="input-title">
              Địa chỉ
              <span class="label-requied">*</span>
            </div>
            <textarea
              tabindex="3"
              @blur="isValidate('storeAddress')"
              id="storeAddress"
              ref="address"
              validate="false"
              v-model="store.address"
              required
              class="border-input-requied"
            ></textarea>
            <div>
              <div class="talk-bubble" id="storeAddress_wrang">
                <div class="talktext">
                  <p>Dữ liệu không hợp lệ</p>
                </div>
              </div>
            </div>
          </div>
          <div class="store-left">
            <label class="input-title">Số điện thoại</label>
            <input
              tabindex="4"
              type="text"
              class="input-notrequied border-input-requied"
              name=""
              placeholder=""
              v-model="store.phoneNumber"
            />
          </div>
          <div class="store-right">
            <label class="input-title">Mã số thuế</label>
            <input
              tabindex="5"
              type="text"
              class="input-notrequied border-input-requied"
              v-model="store.storeTaxCode"
            />
          </div>
          <div class="clear"></div>
          <div class="store-left">
            <label class="input-title">Quốc gia</label>
            <select
              tabindex="6"
              class="input-notrequied border-input-requied"
              v-model="store.countryId"
            >
              <option
                v-for="country in this.countrys"
                :key="country.countryId"
                :value="country.countryId"
              >
                {{ country.countryName }}
              </option>
            </select>
          </div>
          <div class="clear"></div>
          <div class="store-left">
            <label class="input-title">Tỉnh/Thành phố</label>
            <select
              tabindex="7"
              class="input-notrequied border-input-requied"
              v-model="store.provinceId"
            >
              <option
                v-for="province in getProvinceByCountry"
                :key="province.provinceId"
                :value="province.provinceId"
              >
                {{ province.provinceName }}
              </option>
            </select>
          </div>
          <div class="store-right">
            <label class="input-title">Quận/Huyện</label>
            <select
              tabindex="8"
              class="input-notrequied border-input-requied"
              v-model="store.districtId"
            >
              <option
                v-for="district in getDistrictByProvince"
                :key="district.districtId"
                :value="district.districtId"
              >
                {{ district.districtName }}
              </option>
            </select>
          </div>
          <div class="clear"></div>
          <div class="store-left">
            <label class="input-title">Phường/Xã</label>
            <select
              tabindex="9"
              class="input-notrequied border-input-requied"
              v-model="store.wardId"
            >
              <option
                v-for="ward in getWardByDistrict"
                :key="ward.wardId"
                :value="ward.wardId"
              >
                {{ ward.wardName }}
              </option>
            </select>
          </div>
          <div class="store-right">
            <label class="input-title">Đường phố</label>
            <input
              tabindex="10"
              type="text"
              class="input-notrequied border-input-requied"
              v-model="store.street"
            />
          </div>
          <div class="clear"></div>
        </div>
      </div>
      <div class="form-footer">
        <div class="store-left-footer">
          <i class="icon-help"></i>
          <strong>Trợ giúp</strong>
        </div>
        <div class="store-right-footer">
          <button class="btn-save item-center" @click="saveStore" tabindex="11">
            <i class="icon-save"></i>
            <p style="color: white">Lưu</p>
          </button>
          <button class="btn-add item-center" tabindex="12" @click="btnSaveAdd">
            <i class="icon-add"></i>
            <p class="text-insert">Lưu và thêm mới</p>
          </button>
          <div class="btn-cancel item-center" @click="btnClose" tabindex="13">
            <i class="icon-x"></i>
            <p class="text-cancel">Hủy bỏ</p>
          </div>
        </div>
        <div class="clear"></div>
      </div>
    </div>
  </div>
</template>

<script>
import $ from "jquery";
import axios from "axios";
export default {
  name: "StoreListDetail",
  data() {
    return {
      // ĐỐi tượng hiển thị trong combobox
      // CreatedBy: hhminh(13/4/2021)
      countrys: [],
      provinces: [],
      districts: [],
      wards: [],
      // Đối tượng trả về cho Snackbar
      // CreatedBy: hhminh(13/4/2021)
      dataSnackBar: {
        msg: "",
        status: true,
      },
      // Biến chức năng
      // CreatedBy: hhminh(13/4/2021)
      isSaveOrAdd: false,
      isHideToolTip: true,
      isAddOrUpdate: true,
    };
  },
  props: ["isHideDialog", "store", "formMode", "isNameDialog"],
  methods: {
    //Sự kiện kích vào nút lưu và thêm mới
    // CreatedBy: hhminh(13/4/2021)
    btnSaveAdd() {
      this.isSaveOrAdd = true;
      this.saveStore();
    },

    //Sự kiện hủy trong Dialog
    // CreatedBy: hhminh(13/4/2021)
    btnClose() {
      $("#storeCode_wrang").css("display", "none");
      $("#storeName_wrang").css("display", "none");
      $("#storeAddress_wrang").css("display", "none");
      $("#storeCode").removeClass("border-red");
      $("#storeName").removeClass("border-red");
      $("#storeAddress").removeClass("border-red");
      this.$emit("closeDialog", true);
    },

    //Sự kiện nhấn vào nút Lưu/Sửa trong Dialog
    // CreatedBy: hhminh(13/4/2021)
    async saveStore() {
      const me = this;

      //Validate dữ liệu
      var inputValidates = $("input[required], textarea[required]");
      $.each(inputValidates, function (index, input) {
        var entity = inputValidates[index].id;
        var value = $("#" + entity).val();
        // Thêm border và hiện tooltip cho input lỗi
        if (!value) {
          $("#" + entity).addClass("border-red");
          $("#" + entity + "_wrang").css("display", "block");
        } else {
          $("#" + entity).removeClass("border-red");
          $("#" + entity + "_wrang").css("display", "none");
        }
        $(input).trigger("blur");
      });

      // //Focus vào input đầu tiên nếu có lỗi
      // CreatedBy: hhminh(13/4/2021)
      var inputNotValidate = $(
        'input[validate="false"], textarea[validate="false"]'
      );
      if (inputNotValidate && inputNotValidate.length > 0) {
        inputNotValidate[0].focus();
        return;
      }

      //Kiểm tra nếu trạng thái là sửa
      // CreatedBy: hhminh(13/4/2021)
      if (this.formMode == 0) {
        await axios
          .put("http://localhost:52139/api/v1/stores", me.store)
          .then(() => {
            this.handlingSnackbar(true, "Sửa thành công", true);
          })
          .catch(() => {
            // Lấy ra thông báo lỗi
            this.handlingSnackbar(
              false,
              "Mã khách hàng đã có trên hệ thống",
              false
            );
          });
      } else {
        //Ngược lại thì sẽ là trạng thái thêm
        await axios
          .post("http://localhost:52139/api/v1/stores", me.store)
          .then(() => {
            if (this.isSaveOrAdd == true) {
              // Gọi hàm thay đổi đối tượng store về rỗng
              this.$emit("changStore", true);
              this.handlingSnackbar(false, "Thêm thành công", true);
              this.$refs.storeCode.focus();
              // gán lại border cho input và đặt lại validate = false
              var inputs = this.$refs;
              var array = Object.keys(inputs);
              array.map((item) => {
                inputs[item].style.border = "";
                $(inputs[item]).attr("validate", false);
              });
            } else {
              this.handlingSnackbar(true, "Thêm thành công", true);
            }
          })
          .catch(() => {
            this.handlingSnackbar(
              false,
              "Mã khách hàng đã có trên hệ thống",
              false
            );
          });
      }
    },

    // Xử lý Snackbar
    // CreatedBy: hhminh(13/4/2021)
    handlingSnackbar(bool, msg, status) {
      if (bool == true) {
        //Thàng công thì gọi hàm đóng Dialog
        this.btnClose();
      }
      //Gọi hàm Load lại dữ liệu trong bảng
      this.$emit("loadData");
      this.dataSnackBar.msg = msg;
      this.dataSnackBar.status = status;
      this.$emit("changeSnackBar", this.dataSnackBar);
      this.$emit("showSnackbar", false);
    },

    //Hàm validate dữ liệu nhập vào khi blur
    // CreatedBy: hhminh(13/4/2021)
    isValidate(entity) {
      var value = $("#" + entity).val();
      if (!value) {
        $("#" + entity).addClass("border-red");
        $("#" + entity + "_wrang").css("display", "block");
        $("#" + entity).attr("validate", false);
      } else {
        $("#" + entity).removeClass("border-red");
        $("#" + entity + "_wrang").css("display", "none");
        $("#" + entity).attr("validate", true);
      }
    },

    //Các hàm xử lý dữ liệu vào trong combobox
    // Hàm load dữ liệu của quốc gia
    // CreatedBy: hhminh(13/4/2021)
    async loadCountry() {
      await axios.get("http://localhost:52139/api/v1/countrys").then((res) => {
        this.countrys = res.data;
      });
    },
    // Hàm load dữ liệu của tỉnh thành phố
    // CreatedBy: hhminh(13/4/2021)
    async loadProvince() {
      await axios.get("http://localhost:52139/api/v1/provinces").then((res) => {
        this.provinces = res.data;
      });
    },
    // Hàm load dữ liệu của tỉnh thành phố
    // CreatedBy: hhminh(13/4/2021)
    async loadDistrict() {
      await axios.get("http://localhost:52139/api/v1/districts").then((res) => {
        this.districts = res.data;
      });
    },
    // Hàm load dữ liệu của tỉnh thành phố
    // CreatedBy: hhminh(13/4/2021)
    async loadWard() {
      await axios.get("http://localhost:52139/api/v1/wards").then((res) => {
        this.wards = res.data;
      });
    },
  },
  beforeUpdate() {},
  created() {
    this.loadCountry();
    this.loadProvince();
    this.loadDistrict();
    this.loadWard();
  },
  computed: {
    //Lấy tỉnh theo id quốc gia
    // CreatedBy: hhminh(13/4/2021)
    getProvinceByCountry() {
      return this.provinces.filter((x) => x.countryId == this.store.countryId);
    },
    //Lấy quận huyện theo id thành phố
    // CreatedBy: hhminh(13/4/2021)
    getDistrictByProvince() {
      return this.districts.filter(
        (x) => x.provinceId == this.store.provinceId
      );
    },
    //Lấy phường xã theo id quận huyện
    // CreatedBy:hhminh(13/4/2021)
    getWardByDistrict() {
      return this.wards.filter((x) => x.districtId == this.store.districtId);
    },
  },
};
</script>

<style>
/* css cho tooltip */
.isHideToolTip {
  display: none;
}
.red {
  background-color: #f63233;
  color: #ffffff;
}
.black {
  background-color: #000000;
  color: #ffffff;
}
.talk-bubble {
  width: 200px;
  height: 34px;
  background-color: #f63233;
  color: #fff;
  text-align: center;
  border-radius: 4px;
  position: absolute;
  z-index: 99999999999;
  top: 5px;
  left: 101%;
  display: none;
  color: #fbc5c8;
}
.talk-bubble:after {
  content: " ";
  position: absolute;
  width: 0;
  height: 0;
  left: -22px;
  right: auto;
  top: 1px;
  bottom: auto;
  border: 16px solid;
  border-color: transparent #f63233 transparent transparent;
}

.talktext {
  padding: 0.6em;
}
.component-fade-enter-active {
  animation: bounce-in 0.5s;
}
.component-fade-leave-active {
  animation: bounce-out 0.5s;
}
@keyframes bounce-in {
  0% {
    opacity: 0;
  }
  100% {
    opacity: 1;
  }
}
@keyframes bounce-out {
  100% {
    opacity: 0;
  }
}
.text-cancel{
  margin-right: 6px;
}
</style>