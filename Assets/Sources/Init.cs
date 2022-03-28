using UnityEngine;
using Models;
using Presenter;

public class Init : MonoBehaviour
{
    [SerializeField] private float _endPosition;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _rotateMaxSpeed;
    [SerializeField] private float _inertiaSlowdown;
    [SerializeField] private float _gravityScale;
    [SerializeField] private RotationView _view;

    private NutInputRouter _input;
    private Transformable _model;
    private TransformablePresenter _presenter;
    private InertRotation _inertRotation;

    public Transformable Model => _model;

    public NutInputRouter Input => _input;

    public InertRotation InertRotation => _inertRotation;

    private void Awake()
    {
        _model = new Transformable(new Range(0, 360 * _endPosition), new Range(0, _endPosition));
        _inertRotation = new InertRotation(_rotateSpeed, _inertiaSlowdown, _rotateMaxSpeed);
        _input = new NutInputRouter(_inertRotation, _model);
        _presenter = new TransformablePresenter(_model, _view);
    }

    private void OnEnable()
    {
        _input.OnEnable();
        _presenter.OnEnable();
    }

    private void OnDisable()
    {
        _input.OnDisable();
        _presenter.OnDisable();
    }

    private void Update()
    {
        _input.Update();
    }
}