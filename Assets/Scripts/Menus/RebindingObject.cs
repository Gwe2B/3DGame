using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/*
 * Permit to set personnal controls inputs
 */
public class RebindingObject : MonoBehaviour
{
    public InputActionReference actionReference = null;
    public TMP_Text bindingDisplayText = null;

    [SerializeField] public bool is2DVector = false;

    // The binding index 0 => normal, 1 => forward, 2 => backward, 3 => left, 4 => right
    [Range(1, 4)] public int targetBinding = 0;

    private const string processing = "Waiting key...";
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private void Start()
    { bindingDisplayText.text = InputControlPath.ToHumanReadableString(actionReference.action.bindings[is2DVector ? targetBinding : 0].effectivePath); }

    public void StartRebinding()
    {
        bindingDisplayText.text = processing;
        actionReference.action.Disable();

        // Preparing the rebinding
        rebindingOperation = actionReference.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse/delta")       // Ignore mouse movement
            .WithControlsExcluding("Mouse/position")    // Ignore mouse movement
            .WithCancelingThrough("<Keyboard>/escape")  // Set Escape as the cancelling key
            .WithTargetBinding(is2DVector ? targetBinding : 0) // If we are on a composit, wich one is modifying
            .OnComplete((x) =>  // Action when rebinding is completed
            {
                // update button string
                bindingDisplayText.text = InputControlPath.ToHumanReadableString(x.action.bindings[is2DVector ? targetBinding : 0].effectivePath);

                actionReference.action.Enable();
                x.Dispose();
            })
            .OnCancel((x) =>    // Action when rebinding is canceled
            {
                // deselect button
                FindObjectOfType<EventSystem>().SetSelectedGameObject(null);
                x.Dispose();
                actionReference.action.Enable();
            });

        if(actionReference.action.bindings[is2DVector ? targetBinding : 0].isPartOfComposite) { rebindingOperation.WithExpectedControlType("Button"); }
        rebindingOperation.Start();
    }

    public void ResetBinding()
    {
        actionReference.action.RemoveBindingOverride(is2DVector ? targetBinding : 0);
    }
}