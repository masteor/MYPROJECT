using System;
using System.Globalization;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Db.Запросы
{
    public class Запрос
    {
        private const string ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ = " ";
        #region VIEW_EMPLOYEE_FIO

        public struct ViewEmployeeFio
        {
            public const string Select = 
                "SELECT E.ID as ID_USER, " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ +
                "CONCATFIO ( F.NAME_1, F.NAME_2, F.NAME_3) AS FIO_FULL, " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ +
                "EIO.ID_ORG, " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ +
                "cast ((case when O.FNAME is null then '<не определено>' else O.FNAME end) as varchar(50)) AS FNAME," + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ +
                "CONCATFIO ( F.NAME_1, F.NAME_2, F.NAME_3) + ' [' + (case when O.FNAME is null then '<не определено>' else O.FNAME end) + ']' as FIO_FULL_FNAME" + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ + 

                "FROM _EMPLOYEE as E " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ +

                "LEFT JOIN _FIO as F ON E.ID_FIO = F.ID " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ +
                "LEFT JOIN _EMPLOYEE_IN_ORG as EIO on E.ID = EIO.ID_USER" + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ + 
                "LEFT JOIN _ORG as O on EIO.ID_ORG = O.ID" + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ;
        }
        #endregion
        

        #region VIEW_EMPLOYEE_LOGIN

        public struct ViewEmployeeLogin
        {
            /// <summary>
            /// Стандартный запрос без условий 
            /// </summary>
            public const string Select =
                "SELECT " +
            
                "E . ID AS ID_USER ," +
                " CAST ( E . TNUM AS INTEGER ) AS TNUM ," +
                " EMPTYORSELF ( F . NAME_1 ) AS NAME_1 ," +
                " EMPTYORSELF ( F . NAME_2 ) AS NAME_2 , EMPTYORSELF ( F . NAME_3 ) AS NAME_3 , " +
                "CONCATFIO ( F . NAME_1 , F . NAME_2 , F . NAME_3 ) AS FIO_FULL ," +
                " CONCATFIOLOGIN ( F . NAME_1 , F . NAME_2 , F . NAME_3 , L . NAME ) AS FIO_FULL_LOGIN ," +
                "LOWER ( IF_NULL_TAKE_SECOND_VARCHAR ( L . NAME , '<no login name>') ) AS LOGIN_NAME ," +
                "L . ID AS ID_LOGIN , EIO . ID_ORG ," +
                "L . IS_ACTIVE " +
            
                "FROM 1 . _EMPLOYEE AS E " +

                "LEFT JOIN 1 ._LOGIN AS L ON L . ID_USER = E . ID " +
                "LEFT JOIN 1 ._FIO AS F ON F . ID_USER = E . ID " +
                "LEFT JOIN 1 ._EMPLOYEE_IN_ORG AS EIO ON EIO . ID_USER = E . ID" + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ;
            
            /// <summary>
            /// Where-условие для запроса данных с определенным логином
            /// </summary>
            public static Func<string, string> WhereLogin = login 
                => 
                $"WHERE {nameof(VIEW_EMPLOYEE_LOGIN.login_name).ToUpper()}='{login}' " +
                $"AND {nameof(VIEW_EMPLOYEE_LOGIN.is_active).ToUpper()}=TRUE";

        }
        #endregion


        #region VIEW_RESOURCES_BY_OT_ST

        public class ViewResourcesByOtSt
        {
            /*v => v.id_ac_fragment == id_fragment,*/
            public static Func<int, string> WhereIdFragmentId = idFragment => $"WHERE ID_AC_FRAGMENT = {idFragment}";
            
            public static readonly string WhereНаЭтапеРегистрации = 
                $"WHERE CREATE_DATE_1 != null AND CREATE_REQUEST_STATE == {(int?) ИдСтатусаЗаявки.Зарегистрирована}";

            // todo:
            // селект не работает, не знаю почему, пишет синтаксическая ошибка, 
            // а в Рабочем столе Линтер работает
            public static string Select =>
                "SELECT " +
                "ROWNUM AS ID, " +
                "O . ID AS ID_OBJECT, " +
                "R . ID AS ID_RESOURCE, " +
                "O . NAME," +
                "O . ID_OBJECT_TYPE," +
                "OT.ID_SERVICE_TYPE," +
                "OT . CODE AS CODE," +
                "OT . ICON AS ICON," +
                "R . ID_AC_FRAGMENT," +
                "R . ID_USER_RESPONSIBLE," +
                "R.ID_USER_OWNER," +
                "RQ1 . ID AS RQ1_ID," +
                "RQ1 . PARENT AS RQ1_PARENT," +
                "RQ1 . DATE_1 AS CREATE_DATE_1," +
                "RQ1 . DATE_2 AS CREATE_DATE_2," +
                "RQ1 . ID_REQUEST_STATE AS CREATE_REQUEST_STATE, " +
                "RS1 . NAME AS CREATE_REQUEST_STATE_NAME," +
                "RS1 . CODE AS CREATE_REQUEST_STATE_CODE," +
                "RQ2 . ID AS RQ2_ID," +
                "RQ2 .PARENT AS RQ2_PARENT," +
                "RQ2 . DATE_2 AS END_DATE_1," +
                "RQ2 .DATE_2 AS END_DATE_2," +
                "RQ2 . ID_REQUEST_STATE AS END_REQUEST_STATE," +
                "RS2 . NAME AS END_REQUEST_STATE_NAME," +
                "RS2 . CODE AS END_REQUEST_STATE_CODE" + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ + 

                $"FROM {ИмяТаблицы.RESOURCE} AS R" + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ + 

                $"LEFT JOIN {ИмяТаблицы.OBJECT} AS O ON R.ID_OBJECT=O.ID " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ + 
                $"LEFT JOIN {ИмяТаблицы.OBJECT_TYPE} AS OT ON O . ID_OBJECT_TYPE = OT . ID " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ + 
                $"LEFT JOIN {ИмяТаблицы.REQUEST} AS RQ1 ON RQ1 . ID = R . ID_REQUEST_1 " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ + 
                $"LEFT JOIN {ИмяТаблицы.REQUEST_STATE} AS RS1 ON RQ1 . ID_REQUEST_STATE = RS1 . ID " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ +
                $"LEFT JOIN {ИмяТаблицы.REQUEST} AS RQ2 ON RQ2 . ID = R . ID_REQUEST_2 " + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ +
                $"LEFT JOIN {ИмяТаблицы.REQUEST_STATE} AS RS2 ON RQ2 . ID_REQUEST_STATE = RS2 . ID" + ОБЯЗАТЕЛЬНЫЙ_ПРОБЕЛ;

            public const string Select2 =
                "SELECT  ROWNUM AS ID , O . ID AS ID_OBJECT , R . ID AS ID_RESOURCE , O . NAME , O . ID_OBJECT_TYPE , OT . ID_SERVICE_TYPE , OT . CODE AS CODE , OT . ICON AS ICON , R . ID_AC_FRAGMENT , R . ID_USER_RESPONSIBLE , R . ID_USER_OWNER , RQ1 . ID AS RQ1_ID , RQ1 . PARENT AS RQ1_PARENT , RQ1 . DATE_1 AS CREATE_DATE_1 , RQ1 . DATE_2 AS CREATE_DATE_2 , RQ1 . ID_REQUEST_STATE AS CREATE_REQUEST_STATE , RS1 . NAME AS CREATE_REQUEST_STATE_NAME , RS1 . CODE AS CREATE_REQUEST_STATE_CODE , RQ2 . ID AS RQ2_ID , RQ2 . PARENT AS RQ2_PARENT , RQ2 . DATE_2 AS END_DATE_1 , RQ2 . DATE_2 AS END_DATE_2 , RQ2 . ID_REQUEST_STATE AS END_REQUEST_STATE , RS2 . NAME AS END_REQUEST_STATE_NAME , RS2 . CODE AS END_REQUEST_STATE_CODE FROM _RESOURCE AS R LEFT JOIN _OBJECT AS O ON R . ID_OBJECT = O . ID LEFT JOIN _OBJECT_TYPE AS OT ON O . ID_OBJECT_TYPE = OT . ID LEFT JOIN _REQUEST AS RQ1 ON RQ1 . ID = R . ID_REQUEST_1 LEFT JOIN _REQUEST_STATE AS RS1 ON RQ1 . ID_REQUEST_STATE = RS1 . ID LEFT JOIN _REQUEST AS RQ2 ON RQ2 . ID = R . ID_REQUEST_2 LEFT JOIN _REQUEST_STATE AS RS2 ON RQ2 . ID_REQUEST_STATE = RS2 . ID;";
        }
        #endregion
    }
}