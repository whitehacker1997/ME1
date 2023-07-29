namespace OnApp.Core
{
    public class StatusIdConst
    {
        /// <summary>
        /// Создан
        /// </summary>
        public const int CREATED = 1;
        /// <summary>
        /// Отправлен
        /// </summary>
        public const int SENT = 2;
        /// <summary>
        /// Принято
        /// </summary>
        public const int RECEIVED = 3;
        /// <summary>
        /// Для отказа
        /// </summary>
        public const int TO_REJECT = 4;
        /// <summary>
        /// Для утверждения
        /// </summary>
        public const int TO_AGREE = 5;
        /// <summary>
        /// Возврат модератору 
        /// </summary>
        public const int RETURNED_TO_MODERATOR = 6;
        /// <summary>
        /// Согласовано
        /// </summary>
        public const int AGREED = 7;
        /// <summary>
        /// Отказан
        /// </summary>
        public const int REJECTED = 8;
        /// <summary>
        /// Архивный
        /// </summary>
        public const int ARCHIVED = 9;
        /// <summary>
        /// Отозван
        /// </summary>
        public const int REVOKED = 10;
        /// <summary>
        /// Аннулированное соглашение
        /// </summary>
        public const int CANCELED_AGREEMENT = 11;
        /// <summary>
        /// Изменен
        /// </summary> 
        public const int MODIFIED = 12;
        /// <summary>
        /// Перенесенный
        /// </summary> 
        public const int POSTPONED = 13;
        /// <summary>
        /// Продлен
        /// </summary> 
        public const int PROLONGED = 14;
        /// <summary>
        /// Отменено
        /// </summary> 
        public const int CANCELLED = 15;
        ///// <summary>
        ///// Проведено
        ///// </summary>
        public const int HELD = 16;
        ///// <summary>
        ///// Уведомлен
        ///// </summary>
        public const int NOTIFIED = 17;
        /// <summary>
        /// Исполнен
        /// </summary>
        public const int EXECUTED = 18;



        public static readonly int[] CanAgreeStatus = { TO_AGREE, CANCELED_AGREEMENT };
        public static readonly int[] CanCancelAgreementStatus = { AGREED, REJECTED };
        public static readonly int[] CanSendStatus = { CREATED, REVOKED, MODIFIED };
        public static readonly int[] CanNotifyStatus = { CREATED, REVOKED, MODIFIED, SENT, RETURNED_TO_MODERATOR };
        public static readonly int[] CanReceiveStatus = { SENT };
        public static readonly int[] CanToAgreeStatus = { SENT, RECEIVED, RETURNED_TO_MODERATOR };
        public static readonly int[] CanToRejectStatus = { SENT, RECEIVED, RETURNED_TO_MODERATOR };
        public static readonly int[] CanReturnToModeratorStatus = { TO_AGREE, TO_REJECT, CANCELED_AGREEMENT };
        public static readonly int[] CanRejectStatus = { TO_REJECT, CANCELED_AGREEMENT, NOTIFIED };
        public static readonly int[] CanArchiveStatus = { CREATED, MODIFIED, REVOKED };
        public static readonly int[] CanRevokeStatus = { SENT };
        public static readonly int[] CanModifyStatus = { CREATED, REVOKED, MODIFIED };
        public static readonly int[] CanPostponeStatus = { AGREED, NOTIFIED };
        public static readonly int[] CanProlongStatus = { AGREED, NOTIFIED };
        public static readonly int[] CanCancelStatus = { AGREED, NOTIFIED, MODIFIED, CREATED, REVOKED };
        public static readonly int[] CanExecuteStatus = { AGREED, POSTPONED, PROLONGED, NOTIFIED };
        public static readonly int[] CanViewReceiver = { SENT, RECEIVED, TO_AGREE, TO_REJECT, RETURNED_TO_MODERATOR, REJECTED, AGREED, NOTIFIED, CANCELLED, PROLONGED, POSTPONED, EXECUTED };
        public static readonly int[] CanViewReceiver2 = { REJECTED, AGREED, NOTIFIED, CANCELLED, PROLONGED, POSTPONED, EXECUTED };
        public static readonly int[] CanViewAgreer = { TO_AGREE, TO_REJECT, RETURNED_TO_MODERATOR, REJECTED, AGREED, NOTIFIED, CANCELLED, PROLONGED, POSTPONED, EXECUTED };
        public static readonly int[] CanViewAgreer2 = { REJECTED, AGREED, NOTIFIED, CANCELLED, PROLONGED, POSTPONED, EXECUTED };
        public static readonly int[] CanRedirectStatus = { SENT, RECEIVED, RETURNED_TO_MODERATOR };
        public static readonly int[] CanHeldStatus = { SENT, RECEIVED };
        public static readonly int[] CanAttestationRejectStatus = { SENT, RECEIVED };
        public static readonly int[] CanAttestationModifyStatus = { CREATED, REVOKED, MODIFIED, REJECTED };
        public static readonly int[] CanAttachOrderStatus = { AGREED, POSTPONED, PROLONGED, EXECUTED, NOTIFIED };

        public static readonly int[] InspectorStatus = { AGREED, CREATED, MODIFIED, NOTIFIED, REJECTED, SENT };
        public static readonly int[] ModeratorStatus = { AGREED, NOTIFIED, REJECTED, SENT, RETURNED_TO_MODERATOR };
        public static readonly int[] CeoStatus = { AGREED, NOTIFIED, REJECTED, RETURNED_TO_MODERATOR };
        public static readonly int[] AttestationStatus = { CREATED, MODIFIED, SENT, HELD, REJECTED };

        public static bool CanApplyStatus(int currentStatusId, int newStatusId)
        {
            return newStatusId switch
            {
                SENT => CanSendStatus.Contains(currentStatusId),
                RECEIVED => CanReceiveStatus.Contains(currentStatusId),
                TO_REJECT => CanToRejectStatus.Contains(currentStatusId),
                TO_AGREE => CanToAgreeStatus.Contains(currentStatusId),
                RETURNED_TO_MODERATOR => CanReturnToModeratorStatus.Contains(currentStatusId),
                AGREED => CanAgreeStatus.Contains(currentStatusId),
                REJECTED => CanRejectStatus.Contains(currentStatusId),
                ARCHIVED => CanArchiveStatus.Contains(currentStatusId),
                REVOKED => CanRevokeStatus.Contains(currentStatusId),
                CANCELED_AGREEMENT => CanCancelAgreementStatus.Contains(currentStatusId),
                MODIFIED => CanModifyStatus.Contains(currentStatusId),
                POSTPONED => CanPostponeStatus.Contains(currentStatusId),
                PROLONGED => CanProlongStatus.Contains(currentStatusId),
                CANCELLED => CanCancelStatus.Contains(currentStatusId),
                NOTIFIED => CanNotifyStatus.Contains(currentStatusId),
                EXECUTED => CanExecuteStatus.Contains(currentStatusId),
                _ => true,
            };
        }
    }
}
